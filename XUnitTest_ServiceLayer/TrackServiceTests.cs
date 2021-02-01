using AutoMapper;
using Base.BusinessModels;
using BusinessLogicLayer;
using DataLayer;
using DataLayer.DTO;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace XUnitTest_ServiceLayer
{
    public class TrackServiceTests
    {
        private readonly TrackService _trackService;
        private readonly Mock<ITrackRepository> _trackRepoMock = new Mock<ITrackRepository>();
        private readonly Mock<ILogger<TrackEntity>> _logger;
        private readonly Mock<IMapper> _mapper;


        public TrackServiceTests()
        {
            _logger = new Mock<ILogger<TrackEntity>>();
            _mapper = new Mock<IMapper>();
            _trackService = new TrackService(_trackRepoMock.Object, _mapper.Object, _logger.Object);
        }

        [Fact]
        public void GetById_ReturnsCustomer_WhenTrackExists()
        {
            // Arrange
            var trackID = 1;
            var trackName = "Master of Puppets";
            var artistID = 1;
            var trackDTO = new Track
            {
                ID = trackID,
                Name = trackName,
                ArtistID = artistID
            };
            _trackRepoMock.Setup(x => x.GetByID(trackID)).ReturnsAsync(trackDTO);

            // Act
            var track = _trackService.GetByID(trackID);

            // Assert
            Assert.Equal(trackID, track.ID);
            Assert.Equal(trackName, track.Name);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenTrackDoesNotExist()
        {
            // Arrange
            int trackID = 1;
            _trackRepoMock.Setup(x => x.GetByID(trackID)).ReturnsAsync(() => null);

            // Act
            var track = _trackService.GetByID(trackID);

            // Assert
            Assert.Null(track);
        }
    }
}
