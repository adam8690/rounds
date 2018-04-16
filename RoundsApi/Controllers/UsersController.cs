using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoundsApi.Models;

namespace RoundsApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        Dictionary<Guid, User> users;
        public UsersController(Store.InMemoryUserStore userStore)
        {
            users = userStore.users;
        }
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            List<User> userList = new List<User>();
            foreach(KeyValuePair<Guid, User> user in users)
            {
                userList.Add(user.Value);
            }
            return Ok(userList);
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            User foundUser;
            if (users.TryGetValue(id, out foundUser))
            {
                return Ok(foundUser);
            }
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]UserUpsertModel newUser)
        {
            User userToSave = new User()
            {
                userId = Guid.NewGuid(),
                name = newUser.name,
                drink = newUser.drink
            };

            users.Add(userToSave.userId, userToSave);

            return CreatedAtAction("Get", new { userToSave.userId }, userToSave);
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]UserUpsertModel user)
        {
            User foundUser;
            if(users.TryGetValue(id, out foundUser))
            {
                users[id].drink = user.drink;
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            User foundUser;
            if (users.TryGetValue(id, out foundUser))
            {
                users.Remove(id);
            }
            return Ok();
        }
    }
}
