﻿using BOL;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

List<User> userlist = new List<User>();

Console.WriteLine("Enter fully qualified address of folder storing serialised file.");
string location= Console.ReadLine();
location= location+"\\User.json";
string fileName=@location;

try{
string jsonString = File.ReadAllText(fileName);
List<User> jsonUsers = JsonSerializer.Deserialize<List<User>>(jsonString);
Console.WriteLine("\nDeserializing data from json file");
   foreach( User single_user in jsonUsers)
   {
    userlist.Add(single_user);
     Console.WriteLine($"{single_user.User_Id} {single_user.Name} {single_user.Salary} {single_user.Role} {single_user.Appraiser_Id} {single_user.Address} {single_user.Mail_Id}");
   } 
}   
catch(Exception exp){}
finally{}



    int choice= 1;

    while(choice<7 && choice>0){

        Console.WriteLine("\n\nEnter Operation: 1.Insert 2.Update 3.Delete 4.GetById 5.GetAll methods 6.Display All 7.Exit");
 
        string choise_string = Console.ReadLine();
        choice = Convert.ToInt32(choise_string);

    switch(choice){

        case 1:
        Console.WriteLine("\nEnter details: user_id, name, salary, role, appraiser_id, address, mail_id respectively.");
        
        string user_id_string= Console.ReadLine();
        int user_id = Convert.ToInt32(user_id_string);

        string name= Console.ReadLine();

        string salary_string= Console.ReadLine();
        double salary = double.Parse(salary_string);

        string role= Console.ReadLine();

        string appraiser_id_string= Console.ReadLine();
        int appraiser_id = Convert.ToInt32(appraiser_id_string);

        string address= Console.ReadLine();
        string mail_id= Console.ReadLine();

        User useradd = new User(user_id, name, salary, role, appraiser_id, address, mail_id);
        userlist.Add(useradd);
        break;

        case 2:
            Console.WriteLine("\nEnter User Id to Update: ");
            user_id_string= Console.ReadLine();
            user_id = Convert.ToInt32(user_id_string);
            
            int index=-1;
        
            foreach( User single_user in userlist)
           {
                index=index+1;
                if(single_user.User_Id == user_id)
                {
                    break;
                } 
            } 

        Console.WriteLine("\nEnter User name, salary, role, appraiser_id, address, mail_id respectively to Update: \nNote: If you dont want to update any field just press enter to move forward");
        

        name= Console.ReadLine();
        if(name.Length != 0)
        {
            userlist[index].Name= name;
        }


        salary_string= Console.ReadLine();
        if(salary_string.Length != 0)
        {
            salary = double.Parse(salary_string);
            userlist[index].Salary= salary;
        }

        role= Console.ReadLine();
        if(role.Length != 0)
        {
            userlist[index].Role= role;
        }


        appraiser_id_string= Console.ReadLine();
        if(appraiser_id_string.Length != 0)
        {
            appraiser_id = Convert.ToInt32(appraiser_id_string);
            userlist[index].Appraiser_Id= appraiser_id;
        }

        address= Console.ReadLine();
        if(address.Length != 0)
        {
            userlist[index].Address= address;
        }

        mail_id= Console.ReadLine();
        if(mail_id.Length != 0)
        {
            userlist[index].Mail_Id= mail_id;
        }

        break;

        case 3:
            Console.WriteLine("\nEnter User Id to delete: ");

            user_id_string= Console.ReadLine();
            user_id = Convert.ToInt32(user_id_string);
            
            index=-1;
        
            foreach( User single_user in userlist)
           {
                index=index+1;
                if(single_user.User_Id == user_id)
                {
                    break;
                } 
            } 
            userlist.RemoveAt(index);

        break;

        case 4:
            Console.WriteLine("\nEnter User Id to get details: ");
            user_id_string= Console.ReadLine();
            user_id = Convert.ToInt32(user_id_string);
            
            index=-1;
        
            foreach( User single_user in userlist)
           {
                index=index+1;
                if(single_user.User_Id == user_id)
                {
                    Console.WriteLine($"{single_user.User_Id} {single_user.Name} {single_user.Salary} {single_user.Role} {single_user.Appraiser_Id} {single_user.Address} {single_user.Mail_Id}");
                } 
            }  

        break;

        case 5:
            Console.WriteLine("\nPrinting all methods: PLEASE VERIFY THAT YOU SET THE RIGHT PATH FOR BOL.dll");
            string path=@"E:\SDM\AbhishekSaswade\SDM-Project-Performance_Appraisal\.net_day5_assingment\BOL\bin\Debug\net7.0\BOL.dll";
            Console.WriteLine(path);
            Console.WriteLine("IF YOU ARE GETTING AN ERROR THEN PLEASE RESET THE PATH IN PROGRAM.CS FILE SWITCH CASE:5 MANUALLY. \n");


            Assembly asm=Assembly.LoadFile(path);
            string sname=asm.FullName;
            Console.WriteLine(sname);

            Type[] types=asm.GetTypes();

            for( int i=0;i<types.Count();i++){
                string typeName=types[i].Name;
                Console.WriteLine(typeName);
                MethodInfo [] mi=types[i].GetMethods();
                foreach( MethodInfo m in mi){
                  string methodName=m.Name;
                  Console.WriteLine(methodName);
                }
            }

        break;

        case 6:
            try{
          
            List<User> jsonUsers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(fileName));
            Console.WriteLine("\nDeserializing data from json file");
            foreach( User single_user in jsonUsers)
            {
                 Console.WriteLine($"{single_user.User_Id} {single_user.Name} {single_user.Salary} {single_user.Role} {single_user.Appraiser_Id} {single_user.Address} {single_user.Mail_Id}");
            } 
            }   
          
            catch(Exception exp){}
             finally{}
        break;
    }

            try{
            var options=new JsonSerializerOptions {IncludeFields=true};
            var UserJson=JsonSerializer.Serialize<List<User>>(userlist,options);
            File.WriteAllText(fileName,UserJson);
            }   

            catch(Exception exp){}
            finally{}

    }


