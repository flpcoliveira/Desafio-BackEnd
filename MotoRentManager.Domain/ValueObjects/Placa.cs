using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MotoRentManager.Domain.ValueObjects
{
    public partial class Placa(string value)
    {
        public string Value { get; private set; } = SpecialCharacters().Replace(value, string.Empty);

        public bool IsValid()
        {
            if(Value is null)
                return false;

            return ValidPattern().Match(Value).Success;
        }

        [GeneratedRegex("^[A-Z]{3}[0-9][0-9A-J][0-9]{2}$")]
        private static partial Regex ValidPattern();
        [GeneratedRegex(@"(\W|\s|[_])")]
        private static partial Regex SpecialCharacters();

        public static implicit operator Placa(string placa) => new(placa);
    }
}
