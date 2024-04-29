using System;
using System.Collections.Generic;
using System.Text;

namespace Task03
{
    public abstract class Citizen
    {
        string _name;
        string _familyName;
        string _passportID;

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", _name, _familyName);
            }
        }

        public string PassportID
        {
            get
            {
                return _passportID;
            }
        }
        public Citizen(string name, string familyName, string passportID)
        {
            _name = name;
            _familyName = familyName;
            _passportID = passportID;

        }

        public static bool operator ==(Citizen a, Citizen b)
        {
            return a.PassportID == b.PassportID;
        }

        public static bool operator !=(Citizen a, Citizen b)
        {
            return !(a.PassportID == b.PassportID);
        }
    }
    public class Student : Citizen
    {
        public Student(string name, string familyName, string passportID) : base(name, familyName, passportID)
        {
        }
    }

    public class Pensioner : Citizen
    {
        public Pensioner(string name, string familyName, string passportID) : base(name, familyName, passportID)
        {
        }
    }

    public class Worker : Citizen
    {
        public Worker(string name, string familyName, string passportID) : base(name, familyName, passportID)
        {
        }
    }
}