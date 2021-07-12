<!--
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/cnty_scada/cnty_scada_collection/Scada_Data_Demo.js此处编写
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
    import extend from "@/extension/cnty_scada/cnty_scada_collection/Scada_Data_Demo.js";
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
                    cnName: 'Scada数据采集',
                    name: 'cnty_scada_collection/Scada_Data_Demo',
                    url: "/Scada_Data_Demo/",
                    sortName: "CreateDate"
                },
                extend: extend,
                editFormFields: {},
                editFormOptions: [],
                searchFormFields: {},
                searchFormOptions: [],
                columns: [{field:'ID',title:'ID',type:'guid',width:90,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'IsDelete',title:'IsDelete',type:'int',width:90,align:'left',sortable:true},
                       {field:'CreateDate',title:'CreateDate',type:'datetime',width:90,align:'left',sortable:true},
                       {field:'CreateID',title:'CreateID',type:'string',width:80,hidden:true,align:'left'},
                       {field:'Creater',title:'Creater',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'Modifier',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'ModifyDate',type:'datetime',width:90,align:'left',sortable:true},
                       {field:'ModifyID',title:'ModifyID',type:'string',width:80,hidden:true,align:'left'},
                       {field:'RequestUrl',title:'请求路径',type:'string',width:220,align:'left'},
                       {field:'RequestData',title:'请求参数',type:'string',width:220,align:'left'},
                       {field:'ResponseCode',title:'ResponseCode',type:'string',width:220,align:'left'},
                       {field:'ResponseData',title:'ResponseData',type:'string',width:220,align:'left'},
                       {field:'ExtendOne',title:'ExtendOne',type:'string',width:120,align:'left'},
                       {field:'ExtendTwo',title:'ExtendTwo',type:'string',width:120,align:'left'},
                       {field:'ExtendThree',title:'ExtendThree',type:'string',width:120,align:'left'}],
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
