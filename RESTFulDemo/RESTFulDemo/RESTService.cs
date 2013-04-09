using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace RESTFulDemo
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RESTSerivce : IRestSerivce
    {
        
        List<Person> objPerson = new List<Person>();
        int personCount = 0;

        public Person CreatePerson(Person createPerson)
        {
            createPerson.ID = (++personCount).ToString();
            objPerson.Add(createPerson);
            return createPerson;
        }

        public List<Person> GetAllPerson()
        {
            return objPerson.ToList();
        }

        public Person GetAPerson(string id)
        {
            return objPerson.FirstOrDefault(e => e.ID.Equals(id));
        }

        public Person UpdatePerson(string id, Person updatePerson)
        {
            Person p = objPerson.FirstOrDefault(e => e.ID.Equals(id));
            p.Name = updatePerson.Name;
            p.Age = updatePerson.Age;
            return p;
        }

        public void DeletePerson(string id)
        {
            objPerson.RemoveAll(e => e.ID.Equals(id));
        }


    }
}