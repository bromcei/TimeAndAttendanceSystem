using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Tests.UserRepositoryServiceTests
{
    public class CustomDataAttribute : AutoDataAttribute
    {
        public CustomDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UserSpecimenBuilder());
            return fixture;
        })
        { }
    }
}
