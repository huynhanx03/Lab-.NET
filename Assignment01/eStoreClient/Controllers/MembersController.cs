using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class MembersController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public MembersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7211/api/Members";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl + "/GetMembers");
            List<Member>? members = new List<Member>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                members = response.Content.ReadFromJsonAsync<List<Member>>().Result;
            }
            return View(members);
        }

        //GET: MembersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl + "/GetMemberById/" + id);

            Member member = new Member();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                member = response.Content.ReadFromJsonAsync<Member>().Result;
            }

            return View(member);
        }

        //GET: MembersController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member p)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl + "/PostMember", p);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return Redirect("Create");
        }

        //GET: MembersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl + "/GetMemberById/" + id);
            Member member = new Member();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                member = response.Content.ReadFromJsonAsync<Member>().Result;
            }

            return View(member);
        }

        //POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member p)
        {
            if (ModelState.IsValid)
            {
                await client.PutAsJsonAsync(MemberApiUrl + "/UpdateMember/" + id, p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //GET: MembersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await client.DeleteAsync(MemberApiUrl + "/DeleteMember/" + id);
            return RedirectToAction("Index");
        }
    }
}
