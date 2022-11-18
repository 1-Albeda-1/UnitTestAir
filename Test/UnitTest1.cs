using Xunit;
using UserStoryAir;
using UserStoryAir.Models;
using Nuget;

namespace Test
{
    public class UnitTest1
    {
            [Fact]
            public void AddButton()
            {
                NugetLogic RS = new();
                Reys mytest = new()
                {
                    NumberReys = 253,
                    Plane = plane.Airbus,
                    arrivalTime = System.DateTime.Now,
                    NumberPassengers = 100,
                    NumberCrew = 20,
                    SborC = 1500,
                    SborP = 2000,
                    allowance = 3000,

                };
                RS.Add(mytest);
                var result = RS.GetList();
                Assert.Equal(mytest, result[0]);
            }

            [Fact]
            public void ChangeButton()
            {
            NugetLogic RS = new();
            var result = RS.GetList();
            Reys mytest = new()
            {
                NumberReys = 253,
                Plane = plane.Airbus,
                arrivalTime = System.DateTime.Now,
                NumberPassengers = 100,
                NumberCrew = 2,
                SborC = 1500,
                SborP = 2000,
                allowance = 3000,

            };
            RS.Add(mytest);
            Reys mytest2 = new()
            {
                NumberReys = 305,
                Plane = plane.Airbus,
                arrivalTime = System.DateTime.Now,
                NumberPassengers = 170,
                NumberCrew = 30,
                SborC = 1500,
                SborP = 2000,
                allowance = 3000,

            };
            RS.Change(mytest, mytest2);
                Assert.Equal(mytest2, result[0]);
            }

            [Fact]
            public void DeleteButton()
            {
            NugetLogic RS = new();
            Reys mytest = new()
            {
                NumberReys = 253,
                Plane = plane.Airbus,
                arrivalTime = System.DateTime.Now,
                NumberPassengers = 100,
                NumberCrew = 2,
                SborC = 1500,
                SborP = 2000,
                allowance = 3000,

            };
            RS.Add(mytest);
            RS.Remove(mytest);
            var result = RS.GetList();
            Assert.Empty(result);
            }
        
    }
}
