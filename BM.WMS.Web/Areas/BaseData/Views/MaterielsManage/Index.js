


(function () {
    $(function () {

        var _$materielssTable = $('#MaterielssTable');
        var _materielsService = abp.services.app.materiels;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.Materiels.CreateMateriels"),
            edit: abp.auth.hasPermission("Pages.Materiels.EditMateriels"),
            'delete': abp.auth.hasPermission("Pages.Materiels.DeleteMateriels")

        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'BaseData/MaterielsManage/CreateOrEditMaterielsModal',
            scriptUrl: abp.appPath + 'Areas/BaseData/Views/MaterielsManage/_CreateOrEditMaterielsModal.es5.min.js',
            modalClass: 'CreateOrEditMaterielsModal'
        });
        _$materielssTable.jtable({
            title: app.localize('Materiels'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _materielsService.getPagedMaterielssAsync
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
                                    _createOrEditModal.open({ id: data.record.id });
                                });
                        }
                        //删除
                        if (_permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteMateriels(data.record);
                                });
                        }
                        //添加
                        if (_permissions.create) {
                            $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateMateriels") + "' ><i class='fa fa-plus'></i></button>")
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

                materialClassID: {
                    title: app.localize('MaterialClassID'),
                    width: '10%'
                },


                shortCode: {
                    title: app.localize('ShortCode'),
                    width: '10%'
                },


                materialCode: {
                    title: app.localize('MaterialCode'),
                    width: '10%'
                },


                materialName: {
                    title: app.localize('MaterialName'),
                    width: '10%'
                },


                fullName: {
                    title: app.localize('FullName'),
                    width: '10%'
                },


                helperCode: {
                    title: app.localize('HelperCode'),
                    width: '10%'
                },


                model: {
                    title: app.localize('Model'),
                    width: '10%'
                },


                unit: {
                    title: app.localize('Unit'),
                    width: '10%'
                },


                remark: {
                    title: app.localize('Remark'),
                    width: '10%'
                },

            }

        });


        //打开添加窗口SPA
        $('#CreateNewMaterielsButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });




        //刷新表格信息
        $("#ButtonReload").click(function () {
            getMaterielss();
        });




        //模糊查询功能
        function getMaterielss(reload) {
            if (reload) {
                _$materielssTable.jtable('reload');
            } else {
                _$materielssTable.jtable('load', {
                    filtertext: $('#MaterielssTableFilter').val()
                });
            }
        }
        //
        //删除当前materiels实体
        function deleteMateriels(materiels) {
            abp.message.confirm(
                app.localize('MaterielsDeleteWarningMessage', materiels.materialClassID),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            _materielsService.deleteMaterielsAsync({
                                id: materiels.id
                            }).done(function () {
                                getMaterielss(true);
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
        }



        //导出为excel文档
        $('#ExportMaterielssToExcelButton').click(function () {
            _materielsService
                .getMaterielssToExcel({})
                    .done(function (result) {
                        app.downloadTempFile(result);
                    });
        });
        //搜索
        $('#GetMaterielssButton').click(function (e) {
            e.preventDefault();
            getMaterielss();
        });

        //制作Materiels事件,用于请求变化后，刷新表格信息
        abp.event.on('app.createOrEditMaterielsModalSaved', function () {
            getMaterielss(true);
        });

        getMaterielss();


    });
})();
