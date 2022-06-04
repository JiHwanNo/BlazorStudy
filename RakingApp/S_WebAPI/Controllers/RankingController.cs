using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S_WebAPI.Data;
using ShareData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S_WebAPI.Controllers
{
    /*REST (Representational State Transfer)
     * 공식 표준 스펙은 아님
     * 원래 있던 HTTP 통신에서 기능을 '재사용'해서 데이터 송수신 규칙을 만든 것
     * 
     * CRUD
     * verb     GET POST PUT ....
     * 
     * Create
     * POST /api/ranking
     * 아이템 생성 요청 (Body에 실제 정보)
     * 
     * Read
     * GET /api/ranking
     * 모든 아이템 정보를 주세요
     * GET /api/ranking 1
     * 1 아이템 정보를 주세요.
     * 
     * Update아
     * PUT /api/ranking (PUT 보안 문제로 웹에선 활용 X)
     * 아이템 갱신 요청 (Body에 실제 정보)
     * 
     * Delete
     * DELETE /api/ranking/1 (DELETE  보안 문제로 웹에선 활용 X)
     * ID - 1번 아이템을 지워주세요.
     * 
     * ApiController 특징
     * 그냥 C# 객체를 반환해도 된다.
     * null 반환 -> 클라에 204 Response (No Content)
     * string -> text/plain
     * 나머지(int / bool) - > application/json
     */
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;
        public RankingController(ApplicationDbContext con)
        {
            _context = con;
        }


        //Create
        [HttpPost]
        public GameResult AddGameResult([FromBody]GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return gameResult;
        }
        //Read
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> resu = _context.GameResults
               .OrderByDescending(item => item.Score)
               .ToList();

            return resu;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            GameResult resu = _context.GameResults
               .Where(item => item.Id == id)
               .FirstOrDefault();

            return resu;
        }
        //Update
        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(item => item.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.UserId = gameResult.UserId;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }
        //Delete
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var finResult = _context.GameResults
                .Where(item => item.Id == id)
                .FirstOrDefault();

            if (finResult == null)
                return false;

            _context.GameResults.Remove(finResult);
            _context.SaveChanges();

            return true;
        }

    }
}
