using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers
{
    //Rest (Representational State Transfer)
    // 원래 있던 HTTP 통신에서 기능을 '재사용'해서 데이터 송수신 규칙을 만든 것.

    //CRUD
    
    //verb (GET POST PUT ...)

    //Create
    //POST
    // -- 아이템 생성 요청 (Body에 실제 정보)

    //Read
    //GET
    //모든 아이템을 주세요
    //GET ... /1
    //ID = 1 번인 아이템 주세요.

    //Update
    //PUT   보안 문제로 활용 X
    //아이템 갱신 요청(Body에 실제 정보)

    //Delete
    // DELETE 보안 문제로 활용 X
    //아이템을 삭제.


    //ApiController 특징
    // 그냥 C# 객체를 반환해도 된다.
    // null 반환 -> 클라에 204 Response (No Content)
    // string => text/plain
    // 나머지 (int, bool) => application/json

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

        //Read
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(item => item.Score)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            GameResult results = _context.GameResults
                .OrderByDescending(item => item.Id == id)
                .FirstOrDefault();

            return results;
        }
        //Update

        //Delete

    }
}
