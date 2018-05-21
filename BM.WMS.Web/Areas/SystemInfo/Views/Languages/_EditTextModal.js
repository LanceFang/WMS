(function($) {
    app.modals.EditLanguageTextModal = function() {

        var _modalManager;
        var _languageService = abp.services.app.language;
        var _$editLanguageTextForm = null;
        var reloadList;
        this.init = function(modalManager) {
            _modalManager = modalManager;
            reloadList = _modalManager.getOptions().reloadList;
            _$editLanguageTextForm = _modalManager.getModal().find('form[name=EditLanguageTextForm]');
            _$editLanguageTextForm.validate();
        };

        this.save = function() {
            if (!_$editLanguageTextForm.valid()) {
                return;
            }

            _modalManager.setBusy(true);

            _languageService
                .updateLanguageText(_$editLanguageTextForm.serializeFormToObject())
                .done(function() {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    _modalManager.close();
                    //abp.event.trigger('app.editLanguageTextModalSaved');
                    reloadList();
                }).always(function() {
                    _modalManager.setBusy(false);
                });
        };
    };
})(jQuery);