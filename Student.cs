using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isdm_connecting
{
    internal class Student
    {
        int id;
        string name;
        int age;
        float gpa;
        string address;

        public Student setId(int _id){ id = _id; return this; }
        public Student setName(string _name) { name = _name; return this; }
        public Student setAge(int _age) { age = _age; return this; }
        public Student setGpa(float _gpa) { gpa = _gpa; return this; }
        public Student setAddress(string _address) { address = _address; return this; }

        public bool addToDatabase()
        {
            DB db = new DB();
            string sql = "insert into Student values ("+id+", '"+name+"', "+age+", "+gpa+", '"+address+"')";
            return db.execute(sql);
        }

    
    }
}
