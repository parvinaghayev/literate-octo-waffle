namespace Application.Features.Appls.Appeals.RuleManagers.Statics
{
    public static class AppealExceptionMessages
    {
        public static string IsAppealEditableOrDeletableErrorMessage =
            "Müraciət qaralama statusunda olmadığı üçün redaktə və ya silmə əməliyyatı icra edilə bilməz.";

        public static string DoesAppealExistsWithGivenIdErrorMessage = "{0} nömrəli müraciət mövcud deyildir.";

        public static string IsCurrentUserAppealApplicantErrorMessage =
            "{0} nömrəli müraciət hazırki istifadəçiyə məxsus deyildir.";

        public static string IsCurrentAppealDraft =
            "{0} nömrəli müraciət hazırda qaralama statusunda olduğu üçün müraciətə baxış edə bilməzsiniz.";

        public static string DoesCurrentUserHavePhoneNumberErrorMessage =
            @"Müraciət yarada bilmək üçün portalda ""Şəxsi məlumatlar"" bölməsindən telefon nömrənizi əlavə etməlisiniz.";

        public static string DoesPermitExistsWithGivenIdErrorMessage = "{0} nömrəli icazə mövcud deyildir.";
    }
}