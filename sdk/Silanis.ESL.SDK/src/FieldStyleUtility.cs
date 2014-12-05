using System;

namespace Silanis.ESL.SDK
{
    internal class FieldStyleUtility
    {
        internal static string BINDING_DATE = "{approval.signed}";
        internal static string BINDING_NAME = "{signer.name}";
        internal static string BINDING_TITLE = "{signer.title}";
        internal static string BINDING_COMPANY = "{signer.company}";

        public static string Binding(FieldStyle style)
        {
            switch (style)
            {
                case FieldStyle.BOUND_DATE:
                    return BINDING_DATE;
                case FieldStyle.BOUND_NAME:
                    return BINDING_NAME;
                case FieldStyle.BOUND_TITLE:
                    return BINDING_TITLE;
                case FieldStyle.BOUND_COMPANY:
                    return BINDING_COMPANY;
                case FieldStyle.BOUND_QRCODE:
                case FieldStyle.UNBOUND_CUSTOM_FIELD:
                case FieldStyle.UNBOUND_TEXT_FIELD:
                case FieldStyle.UNBOUND_CHECK_BOX:
                case FieldStyle.UNBOUND_RADIO_BUTTON:
                case FieldStyle.DROP_LIST:
                case FieldStyle.TEXT_AREA:
                case FieldStyle.LABEL:
                default:
                    return null;
            }
        }
    }
}