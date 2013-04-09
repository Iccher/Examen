using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTFulDemo
{
    #region IStudents Interface
    [ServiceContract]
    public interface IStudents
    {
        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        [WebGet]
        string ObtenerSaludo();



        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        Student CreateStudent(Student createStudent);

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "")]
        List<Student> GetAllStudent();
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Student GetAStudent(string id);

        //PUT Operation
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        Student UpdateStudent(string id, Student updateStudent);

        //DELETE Operation
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void DeleteStudent(string id);

    }
    #endregion

    #region Student Entity
    [DataContract]
    public class Student
    {
        [DataMember]
        public string birthDate;
        [DataMember]
        public string firtsName;
        [DataMember]
        public string idBooster;
        [DataMember]
        public string lastName;

    }
    #endregion

}
