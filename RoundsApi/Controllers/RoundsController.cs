using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoundsApi.Models;

namespace RoundsApi.Controllers
{
    [Route("api/Rounds")]
    public class RoundsController : Controller
    {
        Dictionary<Guid, Round> rounds;
        public RoundsController(Store.InMemoryRoundStore roundsStore)
        {
            rounds = roundsStore.rounds;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Round> roundList = new List<Round>();
            foreach (KeyValuePair<Guid, Round> round in rounds)
            {
                roundList.Add(round.Value);
            }
            return Ok(roundList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Round foundRound;
            if (rounds.TryGetValue(id, out foundRound))
            {
                return Ok(foundRound);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]RoundUpsertModel newRound)
        {
            Round roundToSave = new Round()
            {
                roundId = Guid.NewGuid(),
                currentUser = newRound.currentUser,
                partyName = newRound.partyName,
                users = newRound.users ?? new List<Guid>()
            };
            rounds.Add(roundToSave.roundId, roundToSave);

            return CreatedAtAction("Get", new { roundToSave.roundId }, roundToSave);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]RoundUpsertModel round)
        {
            Round foundRound;
            if (rounds.TryGetValue(id, out foundRound))
            {
                rounds[id].users = round.users;
                rounds[id].currentUser = round.currentUser;
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid partyId)
        {
            Round foundRound;
            if (rounds.TryGetValue(partyId, out foundRound))
            {
                rounds.Remove(partyId);
            }
            return Ok();
        }
    }
}
