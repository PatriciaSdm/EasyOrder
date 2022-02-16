using EasyOrder.Business.Models.Tools;
using System.Text.RegularExpressions;

namespace EasyOrder.Business.Models.ValueObjects
{
    public class Email
    {
        public const int EmailMaxLength = 254;
        public const int EmailMinLength = 5;
        public string Address { get; private set; }

        protected Email() { }

        public Email(string address)
        {
            if (!Validation(address)) throw new DomainException("E-mail inválido");
            Address = address;
        }
        public static bool Validation(string address)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(address);
        }
    }
}
