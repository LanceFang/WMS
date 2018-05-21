(function ($) {
    app.modals.CreateOrEditLanguageModal = function () {

        var _modalManager;
        var _languageService = abp.services.app.language;
        var _$languageInformationForm = null;
        var reloadList;
        this.init = function (modalManager) {
            _modalManager = modalManager;
            reloadList = _modalManager.getOptions().reloadList;
            _modalManager.getModal()
                .find('#LanguageNameEdit')
                .selectpicker({
                    iconBase: "fa",
                    tickIcon: "fa fa-check"
                });

            _modalManager.getModal()
                .find('#LanguageIconEdit')
                .selectpicker({
                    iconBase: "famfamfam-flag",
                    tickIcon: "fa fa-check"
                });

            _$languageInformationForm = _modalManager.getModal().find('form[name=LanguageInformationsForm]');
        };

        this.save = function () {
            var language = _$languageInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _languageService.createOrUpdateLanguage({
                language: language
            }).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                //abp.event.trigger('app.createOrEditLanguageModalSaved');
                reloadList();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);