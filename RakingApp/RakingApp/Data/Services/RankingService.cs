using RakingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakingApp.Data.Services
{
    /*
     * CRUD는 대부분의 컴퓨터 소프트웨어가 가지는 기본적인 데이터 처리 기능인
     * Create(생성), Read(읽기), Update(갱신), Delete(삭제)를 묶어서 일컫는 말이다. 
     * 사용자 인터페이스가 갖추어야 할 기능(정보의 참조/검색/갱신)을 가리키는 용어로서도 사용된다.
     */


    public class RankingService
    {
        ApplicationDbContext _context;
        public RankingService(ApplicationDbContext con)
        {
            _context = con;
        }
        //Create
        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }
        //Read
        public Task<List<GameResult>> GetGameResultsAsyc()
        {
            List<GameResult> results = _context.GameResults.OrderByDescending(item => item.Score).ToList();

            return Task.FromResult( results);
        }

        //Update
        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);
            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return Task.FromResult(true);
             
        }
        //Delete


        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            _context.GameResults.Remove(gameResult);
            _context.SaveChanges();


            return Task.FromResult(true);
        }
    }
}
