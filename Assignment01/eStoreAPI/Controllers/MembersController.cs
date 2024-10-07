using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers() => repository.GetMembers();
        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id) => repository.GetMemberByID(id);

        [HttpPost]
        public IActionResult PostMember([FromBody] Member m)
        {
            repository.AddMember(m);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var p = repository.GetMemberByID(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteMember(p);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] Member p)
        {
            var tmp = repository.GetMemberByID(id);
            if (tmp == null)
            {
                return NotFound();
            }
            repository.UpdateMember(p);
            return NoContent();
        }
    }
}
