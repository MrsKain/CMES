using Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cnty.Core.Enums;

namespace Cnty.Core.Model
{
    /// <summary>
    /// 生成查询条件
    /// </summary>
    public class SQLHelper
    {
        #region 查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static string GetConditions(IList<ConditionInfo> conditions)
        {
            string sqlCondition = "";
            if (conditions == null)
                return sqlCondition;
            //对于in和not in查询，如果没有查询值，不要生成查询条件
            var inConditions = conditions.Where(o => o.Operator == ConditionOper.In || o.Operator == ConditionOper.NotIn).ToList();
            foreach (var inCondition in inConditions)
            {
                if (string.IsNullOrEmpty(inCondition.Value))
                {
                    conditions.Remove(inCondition);
                }
            }

            //筛选出子查询条件
            var subQueryCondition = conditions.Where(t => t.Operator == ConditionOper.Exists || t.Operator == ConditionOper.NotExists).ToList();
            conditions = conditions.Where(t => t.Operator != ConditionOper.Exists && t.Operator != ConditionOper.NotExists).ToList();
            GenerationIndex(conditions);
            var groupNames = conditions.Select(o => o.Group).Distinct().ToList();
            foreach (var groupName in groupNames)//根据分组生成条件，每个分组用括号分隔
            {
                if (groupName != groupNames.First())//对于第一个分组，不需要and或者or
                {
                    var groupRelation = conditions.Where(o => o.Group == groupName).Select(o => o.GroupRelation).First();
                    if (groupRelation == ConditionRelation.And)
                    {
                        sqlCondition += " and ";
                    }
                    else
                    {
                        sqlCondition += " or ";
                    }
                }
                sqlCondition += "(";
                //分组内的查询条件
                var groupConditions = conditions.Where(o => o.Group == groupName).ToList();
                foreach (var groupCondition in groupConditions)
                {
                    if (groupCondition != groupConditions.First())//第一个查询条件，不需要and或者or
                    {
                        if (groupCondition.Relation == ConditionRelation.And)
                        {
                            sqlCondition += " and ";
                        }
                        else
                        {
                            sqlCondition += " or ";
                        }
                    }
                    sqlCondition += GetOperationCondition(groupCondition);
                }
                sqlCondition += ")";
            }
            if (string.IsNullOrEmpty(sqlCondition))
                sqlCondition = "1=1";

            //处理子查询
            if (subQueryCondition.Any())
            {
                foreach (var condition in subQueryCondition)
                {

                    switch (condition.Operator)
                    {
                        case ConditionOper.Exists:
                            if (string.IsNullOrEmpty(sqlCondition))
                            {
                                sqlCondition = $"  exists ({condition.Value})";
                            }
                            else
                            {
                                sqlCondition += $" and exists ({condition.Value})";
                            }
                            break;
                        case ConditionOper.NotExists:
                            if (string.IsNullOrEmpty(sqlCondition))
                            {
                                sqlCondition = $" not exists ({condition.Value})";
                            }
                            else
                            {
                                sqlCondition += $" and not exists ({condition.Value})";
                            }
                            break;
                        default:
                            break;
                    }

                }

            }
            return sqlCondition;
        }
        private static string GetOperationCondition(ConditionInfo condition)
        {
            string columnName = condition.ColumnName;

            string operationCondition = (string.IsNullOrWhiteSpace(condition.Alias) ? "" : (condition.Alias + ".")) + "[" + columnName + "]";
            if (condition.Value != null)
            {
                string operation = "";
                switch (condition.Operator)
                {
                    case ConditionOper.Equal:
                        operation = "=";
                        break;
                    case ConditionOper.Unequal:
                        operation = "!=";
                        break;
                    case ConditionOper.GreaterThan:
                        operation = ">";
                        break;
                    case ConditionOper.GreaterThanEqual:
                        operation = ">=";
                        break;
                    case ConditionOper.LessThan:
                        operation = "<";
                        break;
                    case ConditionOper.LessThanEqual:
                        operation = "<=";
                        break;
                    case ConditionOper.In:
                        operation = "in";
                        break;
                    case ConditionOper.NotIn:
                        operation = "not in";
                        break;
                    case ConditionOper.AllLike:
                    case ConditionOper.LeftLike:
                    case ConditionOper.RightLike:
                        operation = "like";
                        break;
                }
                operationCondition += " " + operation + " ";
                columnName = columnName + "_" + condition.Index;
                operationCondition += "@" + columnName;
            }
            else
            {
                if (condition.Operator == ConditionOper.Equal)
                {
                    operationCondition += " is null";
                }
                else if (condition.Operator == ConditionOper.Unequal)
                {
                    operationCondition += " is not null";
                }
                else
                {
                    throw new IOException("null条件，只能使用“Equal”和“Unequal”比对");
                }
            }
            return operationCondition;
        }
        /// <summary>
        /// 获取查询参数
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static DynamicParameters GetParameters(IList<ConditionInfo> conditions)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (conditions == null)
                return parameters;
            GenerationIndex(conditions);
            foreach (var condition in conditions)
            {
                var columnName = condition.ColumnName;
                columnName = columnName + "_" + condition.Index;
                var value = condition.Value;
                switch (condition.DataType)
                {
                    case DataType.String:
                        switch (condition.Operator)
                        {
                            case ConditionOper.Equal:
                            case ConditionOper.GreaterThan:
                            case ConditionOper.GreaterThanEqual:
                            case ConditionOper.LessThan:
                            case ConditionOper.LessThanEqual:
                            case ConditionOper.Unequal:
                                parameters.Add(columnName, value);
                                break;
                            case ConditionOper.AllLike:
                                parameters.Add(columnName, "%" + value + "%");
                                break;
                            case ConditionOper.LeftLike:
                                parameters.Add(columnName, "%" + value);
                                break;
                            case ConditionOper.RightLike:
                                parameters.Add(columnName, value + "%");
                                break;
                            case ConditionOper.In:
                            case ConditionOper.NotIn:
                                parameters.Add(columnName, (value ?? "").Split('|').ToList());
                                break;
                        }
                        break;
                    case DataType.Int:
                        int? intValue = string.IsNullOrEmpty(value) ? null : (int?)int.Parse(value);
                        List<int> intListValue = (value ?? "").Split('|').Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => int.Parse(o)).ToList();
                        switch (condition.Operator)
                        {
                            case ConditionOper.Equal:
                            case ConditionOper.GreaterThan:
                            case ConditionOper.GreaterThanEqual:
                            case ConditionOper.LessThan:
                            case ConditionOper.LessThanEqual:
                            case ConditionOper.Unequal:
                                parameters.Add(columnName, intValue);
                                break;
                            case ConditionOper.In:
                            case ConditionOper.NotIn:
                                parameters.Add(columnName, intListValue);
                                break;
                            default:
                                throw new InfoException("字段" + columnName + "是" + condition.DataType.ToString() + "型字段，不能进行" + condition.Operator.ToString() + "运算");
                        }
                        break;
                    case DataType.Decimal:
                        Decimal? decimalValue = string.IsNullOrEmpty(value) ? null : (Decimal?)Decimal.Parse(value);
                        List<Decimal> decimalListValue = (value ?? "").Split('|').Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => Decimal.Parse(o)).ToList();
                        switch (condition.Operator)
                        {
                            case ConditionOper.Equal:
                            case ConditionOper.GreaterThan:
                            case ConditionOper.GreaterThanEqual:
                            case ConditionOper.LessThan:
                            case ConditionOper.LessThanEqual:
                            case ConditionOper.Unequal:
                                parameters.Add(columnName, decimalValue);
                                break;
                            case ConditionOper.In:
                            case ConditionOper.NotIn:
                                parameters.Add(columnName, decimalListValue);
                                break;
                            default:
                                throw new InfoException("字段" + columnName + "是" + condition.DataType.ToString() + "型字段，不能进行" + condition.Operator.ToString() + "运算");
                        }
                        break;
                    case DataType.Boolean:
                        bool? boolValue = string.IsNullOrEmpty(value) ? null : (bool?)bool.Parse(value);
                        List<bool> boolListValue = (value ?? "").Split('|').Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => bool.Parse(o)).ToList();
                        switch (condition.Operator)
                        {
                            case ConditionOper.Equal:
                            case ConditionOper.GreaterThan:
                            case ConditionOper.GreaterThanEqual:
                            case ConditionOper.LessThan:
                            case ConditionOper.LessThanEqual:
                            case ConditionOper.Unequal:
                                parameters.Add(columnName, boolValue);
                                break;
                            case ConditionOper.In:
                            case ConditionOper.NotIn:
                                parameters.Add(columnName, boolListValue);
                                break;
                            default:
                                throw new InfoException("字段" + columnName + "是" + condition.DataType.ToString() + "型字段，不能进行" + condition.Operator.ToString() + "运算");
                        }
                        break;
                    case DataType.DateTime:
                        DateTime? dateTimeValue = string.IsNullOrEmpty(value) ? null : (DateTime?)DateTime.Parse(value);
                        List<DateTime> dateTimeListValue = (value ?? "").Split('|').Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => DateTime.Parse(o)).ToList();
                        switch (condition.Operator)
                        {
                            case ConditionOper.Equal:
                            case ConditionOper.GreaterThan:
                            case ConditionOper.GreaterThanEqual:
                            case ConditionOper.LessThan:
                            case ConditionOper.LessThanEqual:
                            case ConditionOper.Unequal:
                                parameters.Add(columnName, dateTimeValue);
                                break;
                            case ConditionOper.In:
                            case ConditionOper.NotIn:
                                parameters.Add(columnName, dateTimeListValue);
                                break;
                            default:
                                throw new InfoException("字段" + columnName + "是" + condition.DataType.ToString() + "型字段，不能进行" + condition.Operator.ToString() + "运算");
                        }
                        break;
                }
            }
            return parameters;
        }

        /// <summary>
        /// 生成排序条件
        /// </summary>
        /// <typeparam name="T">需要排序的对象类型</typeparam>
        /// <param name="source">linq表达式</param>
        /// <param name="property">排序的字段名称</param>
        /// <param name="methodName">排序方向</param>
        /// <returns></returns>
        public static string GetSorts(IList<SortInfo> sortConditions)
        {
            string sqlSortConditions = "";
            foreach (var sortCondition in sortConditions)
            {
                sqlSortConditions += (string.IsNullOrWhiteSpace(sortCondition.Alias) ? "" : sortCondition.Alias + ".") + "[" + sortCondition.ColumnName + "]";
                sqlSortConditions += " " + (sortCondition.Direction == ConditionDirection.ASC ? "asc" : "desc") + ",";
            }
            sqlSortConditions = sqlSortConditions.Trim(',');
            return sqlSortConditions;
        }
        #endregion
        private static void GenerationIndex(IList<ConditionInfo> conditions)
        {
            var columnNames = conditions.GroupBy(o => o.ColumnName).Select(o => new
            {
                Name = o.Key,
                Count = o.Count()
            }).Where(o => o.Count > 0).Select(o => o.Name);
            foreach (var columnName in columnNames)
            {
                var datas = conditions.Where(o => o.ColumnName == columnName).ToList();
                for (var i = 0; i < datas.Count(); i++)
                {
                    datas[i].Index = i;
                }
            }
        }
    }
}
