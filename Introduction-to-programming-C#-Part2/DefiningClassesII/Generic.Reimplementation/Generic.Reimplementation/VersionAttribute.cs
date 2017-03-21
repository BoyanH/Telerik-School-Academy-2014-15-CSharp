using System;

namespace Generic.Reimplementation
{
    class VersionAttribute : System.Attribute
    {
        private string major;
        private string minor;

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.major, this.minor);
            }
            set
            {
                string[] argsArr = value.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (argsArr.Length != 2)
                {
                    throw new Exception("Attr must be in format major.minor!");
                }

                this.major = argsArr[0];
                this.minor = argsArr[1];
            }
        }

        public VersionAttribute(string version)
        {
            string[] argsArr = version.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (argsArr.Length != 2)
            {
                throw new Exception("Attr must be in format major.minor!");
            }

            this.major = argsArr[0];
            this.minor = argsArr[1];
        }
    }
}
