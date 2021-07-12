<!--
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/rgm/cnty.rgm/Rgm_In_Data.js此处编写
 -->
<template>
    <div>
        <view-grid
                   ref="grid"
                   :columns="columns"
                   :detail="detail"
                   :editFormFields="editFormFields"
                   :editFormFileds="editFormFields"
                   :editFormOptions="editFormOptions"
                   :searchFormFields="searchFormFields"
                   :searchFormFileds="searchFormFields"
                   :searchFormOptions="searchFormOptions"
                   :table="table"
                   :extend="extend">
        </view-grid>
    </div>
</template>

<script>
    import extend from "@/extension/rgm/cnty.rgm/Rgm_In_Data.js";
    import ViewGrid from "@/components/basic/ViewGrid.vue";
    var vueParam = {
        components: {
            ViewGrid
        },
        data() {
            return {
                table: {
                    key: 'ID',
                    footer: "Foots",
                    cnName: '入料管控',
                    name: 'cnty.rgm/Rgm_In_Data',
                    url: "/Rgm_In_Data/",
                    sortName: "CreateDate"
                },
                extend: extend,
                editFormFields: {},
                editFormOptions: [],
                searchFormFields: {},
                searchFormOptions: [],
                columns: [{field:'ID',title:'主键',type:'guid',width:90,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'IsDelete',title:'是否删除0未删除1删除',type:'int',width:90,align:'left',sortable:true},
                       {field:'Modifier',title:'更新人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'更新日期',type:'datetime',width:90,align:'left',sortable:true},
                       {field:'ModifyID',title:'更新人ID',type:'string',width:80,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:90,align:'left',sortable:true},
                       {field:'CreateID',title:'创建ID',type:'string',width:80,hidden:true,align:'left'},
                       {field:'Creater',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'LicensePlate',title:'车牌',type:'string',width:120,align:'left'},
                       {field:'StorageVolume',title:'入库量',type:'string',width:120,align:'left'},
                       {field:'InTime',title:'入库时间',type:'datetime',width:90,align:'left',sortable:true},
                       {field:'KeepData1',title:'备存数据1',type:'string',width:120,align:'left'},
                       {field:'KeepData2',title:'备存数据2',type:'string',width:120,align:'left'}],
                detail: {
                    cnName:"#detailCnName",
                    columns: [],
                    sortName: "",
                    key:""
                }
            };
        }
    };
    export default vueParam;
</script>
