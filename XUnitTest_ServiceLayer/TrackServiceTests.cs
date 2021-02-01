using AutoMapper;
using Base.BusinessModels;
using BusinessLogicLayer;
using BusinessLogicLayer.MapProfiles;
using DataLayer;
using DataLayer.DTO;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest_ServiceLayer
{
    public class TrackServiceTests
    {
        private readonly TrackService _trackService;
        private readonly Mock<ITrackRepository> _trackMockRepo = new Mock<ITrackRepository>();
        private readonly Mock<ILogger<TrackEntity>> _logger = new Mock<ILogger<TrackEntity>>();


        public TrackServiceTests()
        {
            var myProfile = new TrackProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _trackService = new TrackService(_trackMockRepo.Object, mapper, _logger.Object);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenTrackDoesNotExist()
        {
            // Arrange
            int trackID = 1;
            _trackMockRepo.Setup(x => x.GetByID(trackID)).Returns(() => null);

            // Act
            var track = _trackService.GetByID(trackID);

            // Assert
            Assert.Null(track);
        }

        [Fact]
        public void GetById_ReturnsTrack_WhenTrackExists()
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
            _trackMockRepo.Setup(x => x.GetByID(trackID)).ReturnsAsync(trackDTO);

            // Act
            TrackEntity track = _trackService.GetByID(trackID);

            // Assert
            Assert.Equal(trackID, track.ID);
            Assert.Equal(trackName, track.Name);
        }

        [Fact]
        public void GetAll_ReturnsTracks_WhenTheyExist()
        {
            // Arrange
            _trackMockRepo.Setup(x => x.GetAll())
                .ReturnsAsync(new List<Track>()
                {
                    new Track(), new Track()
                });

            // Act
            var tracks = _trackService.GetAll();

            // Assert
            Assert.Equal(2,tracks.Count);
        }
    }
}
