using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class Detector
    {
        private bool isCorrectEmail = true;
        public Detector(String email)
        {
            if (email.Length < 12)
            {
                isCorrectEmail = false;
                return;
            }
            if (!email.Contains("@"))
            {
                isCorrectEmail = false;
                return;
            }
            if (!email.Split('@')[1].Contains("."))
            {
                isCorrectEmail = false;
            }
        }

        public bool getIsCorrectEmail() { return isCorrectEmail; }

        public bool getIsCorrectPassword(String password)
        {
            if (password.Length >= 8 && password.Length <= 32){ return true; }

            return false;
        }
    }
}
