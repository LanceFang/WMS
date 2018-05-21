(function ($) {
   

    app.modals.CreateOrEditMaterielsClassesModal = function () {
        var _modalManager;
        var _materielsClassesService = abp.services.app.materielsClasses;

        var _$materielsClassesInformationForm = null;
        var reloadList;
        this.init = function (modalManager) {
            _modalManager = modalManager;
            reloadList = _modalManager.getOptions().reloadList;
            _$materielsClassesInformationForm = _modalManager.getModal().find("form[name=materielsClassesInformationsForm]");
            
        }

        this.save = function () {
            if (!_$materielsClassesInformationForm.valid()) {
                return;
            }
            //校验通过

            var materielsClasses = _$materielsClassesInformationForm.serializeFormToObject();
            //  console.log(materielsClasses);

            _modalManager.setBusy(true);

            _materielsClassesService.createOrUpdateMaterielsClassesAsync({
                materielsClassesEditDto: materielsClasses
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                //abp.event.trigger('app.createOrEditMaterielsClassesModalSaved');
                reloadList();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

