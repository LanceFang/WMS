(function () {
    $(function () {

        var _$storeInfosTable = $('#StoreInfosTable');
        var _storeInfoService = abp.services.app.storeInfo;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.StoreInfo.CreateStoreInfo"),
            edit: abp.auth.hasPermission("Pages.StoreInfo.EditStoreInfo"),
            'delete': abp.auth.hasPermission("Pages.StoreInfo.DeleteStoreInfo")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'BaseData/StoreInfoManage/CreateOrEditStoreInfoModal',
            scriptUrl: abp.appPath + 'Areas/BaseData/Views/StoreInfoManage/_CreateOrEditStoreInfoModal.es5.min.js',
            modalClass: 'CreateOrEditStoreInfoModal'
        });

    



        _$storeInfosTable.jtable({

            title: app.localize('StoreInfo'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _storeInfoService.getPagedStoreInfosAsync
        }
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                    }
                    //删除
                    if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteStoreInfo(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateStoreInfo") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                    }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

storeCode: {
            title: app.localize('StoreCode'),
            width: '10%'
         },     
	  

storeName: {
            title: app.localize('StoreName'),
            width: '10%'
         },     
	  

storeAddress: {
            title: app.localize('StoreAddress'),
            width: '10%'
         },     
	  

userId: {
            title: app.localize('UserId'),
            width: '10%'
         },     
	  

userName: {
            title: app.localize('UserName'),
            width: '10%'
         },     
	  

remark: {
            title: app.localize('Remark'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewStoreInfoButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getStoreInfos();
        });




//模糊查询功能
function getStoreInfos(reload) {
    if (reload) {
        _$storeInfosTable.jtable('reload');
    } else {
        _$storeInfosTable.jtable('load', {
            filtertext: $('#StoreInfosTableFilter').val()
        });
    }
}
//
//删除当前storeInfo实体
function deleteStoreInfo(storeInfo) {   
    abp.message.confirm(
        app.localize('StoreInfoDeleteWarningMessage', storeInfo. storeCode),
            function (isConfirmed) {
                if (isConfirmed) {
                    _storeInfoService.deleteStoreInfoAsync({
                        id: storeInfo.id
                        }).done(function () {
                            getStoreInfos(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportStoreInfosToExcelButton').click(function () {
    _storeInfoService
        .getStoreInfosToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetStoreInfosButton').click(function (e) {
    e.preventDefault();
    getStoreInfos();
});

//制作StoreInfo事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditStoreInfoModalSaved', function () {
    getStoreInfos(true);
});

getStoreInfos();
 
 
    });
})();
