using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.ServiceModel.Activation;

namespace RESTFulDemo
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Students : IStudents
    {
        List<Student> objStudent = new List<Student>();
        int StudentCount = 0;

        public Student CreateStudent(Student createStudent)
        {
            createStudent.idBooster = (++StudentCount).ToString();
            objStudent.Add(createStudent);
            return createStudent;
        }

        public List<Student> GetAllStudent()
        {
            return objStudent.ToList();
        }

        public Student GetAStudent(string id)
        {
            return objStudent.FirstOrDefault(e => e.idBooster.Equals(id));
        }

        public Student UpdateStudent(string id, Student updateStudent)
        {
            Student p = objStudent.FirstOrDefault(e => e.idBooster.Equals(id));
            p.birthDate = updateStudent.birthDate;
            p.firtsName = updateStudent.firtsName;
            p.lastName = updateStudent.lastName;
            return p;
        }

        public void DeleteStudent(string id)
        {
            objStudent.RemoveAll(e => e.idBooster.Equals(id));
        }


        public string ObtenerSaludo()
        {
            var hora = DateTime.Now.Hour;
            if (hora < 12)
                return "Buenos Dias";
            else if (hora < 19)
                return "Buenas Tardes";
            else
                return "Buenas Noches";
        }
    }
}
