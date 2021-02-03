using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Backend.API.Web.Core;
using Backend.API.Data.Entities;


namespace Backend.API.Web
{
    public static class UsersHttpTrigger
    {        
        [FunctionName("UsersList")]
        public static async Task<IActionResult> RunGetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Users/All")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");            

            //intialize entities of business logic            
            Users users = new Users();        
                    
            IEnumerable<UserEntity>  usersList = await users.getUsersList();
            return new OkObjectResult(usersList);            
        }

        [FunctionName("UserGetById")]
        public static async Task<IActionResult> RunGetById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Users/GetById/{id}")] HttpRequest req, string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");            

            //intialize entities of business logic            
            Users users = new Users();

            //if the request is to get the user by id            
            if(!string.IsNullOrEmpty(id))
            {                
                UserEntity user = await users.getById(Convert.ToInt32(id));
                return new OkObjectResult(user);
            }

            //otherwise (if id is null)
            return new BadRequestObjectResult("Please pass a Id as a route parameter");                       
        }

        [FunctionName("UsersGetByEmail")]
        public static async Task<IActionResult> RunGetByEmail(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Users/GetByEmail/{email}")] HttpRequest req, string email,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");            

            //intialize entities of business logic            
            Users users = new Users();

            //if the request is to get the users by email                   
            if (!string.IsNullOrEmpty(email))
            {           
                IEnumerable<UserEntity> usersList = await users.getUsersByEmail(email);
                return new OkObjectResult(usersList);
            }

            //otherwise (if var email is null)
            return new BadRequestObjectResult("Please pass a Email as a route parameter");                       
        }
    }
}
