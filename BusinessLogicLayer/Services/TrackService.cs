using AutoMapper;
using Base.BusinessModels;
using DataLayer;
using DataLayer.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TrackEntity> _logger;

        public TrackService(ITrackRepository trackReporistory, IMapper mapper, ILogger<TrackEntity> logger)
        {
            _trackRepository = trackReporistory;
            _mapper = mapper;
            _logger = logger;
        }

        public TrackEntity GetByID(int ID)
        {
            var track = _trackRepository.GetByID(ID).Result;
            if(track == null)
            {
                _logger.LogInformation("Unable to find track with ID: {Id}", ID);
                return null;
            }

            _logger.LogInformation("Found track with ID: {Id}", track.ID);
            return _mapper.Map<TrackEntity>(track);
        }

        public List<TrackEntity> GetAll()
        {
            var trackList = _trackRepository.GetAll().Result;

            _logger.LogInformation("Found {amount} tracks", trackList.Count());

            return _mapper.Map<List<TrackEntity>>(trackList);
        }

        public bool Add(TrackEntity newTrack)
        {
            var trackDTO = _mapper.Map<Track>(newTrack);
            var opSuccess = _trackRepository.Add(trackDTO).Result;
            if(!opSuccess)
            {
                _logger.LogInformation("Failed to add new track.");
                return opSuccess;
            }

            _logger.LogInformation("Added new track.");
            return opSuccess;
        }

        public bool Update(TrackEntity track)
        {
            var trackDTO = _mapper.Map<Track>(track);
            var opSuccess =  _trackRepository.Update(trackDTO).Result;
            if (!opSuccess)
            {
                _logger.LogInformation("Failed to edit track.");
                return opSuccess;
            }

            _logger.LogInformation("Edited track.");
            return opSuccess;
        }

        public bool Delete(int ID)
        {
            var opSuccess = _trackRepository.Delete(ID).Result;

            if (!opSuccess)
            {
                _logger.LogInformation("Failed to delete track.");
                return opSuccess;
            }

            _logger.LogInformation("Deleted track.");
            return opSuccess;
        }
    }
}
