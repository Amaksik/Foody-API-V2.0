using FoodyAPI.Controllers;
using FoodyAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodyAPI.Repository
{

    public class UsersRepository
    {

        //reading from json
        public UsersData DataRead()
        {
            string json;
            using (StreamReader sr = new StreamReader("Data\\json.json") )
            {
                json = sr.ReadToEnd();
            }
            var data = JsonSerializer.Deserialize<UsersData>(json);
            return data;
        }

        //writing data to json
        public void DataSave(UsersData data)
        {

            var @string = JsonSerializer.Serialize(data);

            using (StreamWriter sr = new StreamWriter("Data\\json.json"))
            {
                sr.Write(@string);
            }
        }


        //adding new user to list
        public void Add(User ur)
        {
            UsersData info = DataRead();

            if (info.users == null)
            {
                info.users = new List<User>();
            }

            if (IsInside(ur.id) == false) 
            { 
                info.users.Add(ur);
                ur.Favourite = new List<Product>();
            }

            DataSave(info);
        }


        public void AddProduct(User ur, Product pr)
        {
            UsersData info = DataRead();
            User usr = ReturnUser(ur.id);

            usr.Favourite.Add(pr);
            info.users.Remove(ur);
            info.users.Add(usr);

            DataSave(info);
        }


        //checking if there is a user in list
        public bool IsInside(string id)
        {
            UsersData info = DataRead();
            var result = false;
            if (info.users == null)
            {
                return false;
            }
            if (info.users.Count > 0)
            {
                foreach (User us in info.users)
                {
                    if (id == us.id)
                    {
                        result = true;
                    }
                }
                
            }
            return result;

        }


        //gives the user by id
        public User ReturnUser(string id)
        {
            UsersData info = DataRead();
            User findetuser = new User();
            foreach (User us in info.users)
            {
                if (id == us.id)
                {
                    findetuser = us;
                }
                
            }
            return findetuser;
        }


        //removing user from the list
        public void Remove(User ur)
        {
            try
            {
                UsersData info = DataRead();
                User foremove = ReturnUser(ur.id);
                info.users.Remove(foremove) ;

                DataSave(info);

            }
            catch (Exception)
            {

            }
           

        }
    }
}
