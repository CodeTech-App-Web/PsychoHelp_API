using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Appointments.Domain.Repositories;
using PsychoHelp_API.Appointments.Domain.Services;
using PsychoHelp_API.Appointments.Domain.Services.Communication;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services.Communication;

namespace PsychoHelp_API.Appointments.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _appointmentRepository.ListAsync();
        }

        public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(appointment);
            }
            catch(Exception e)
            {
                return new AppointmentResponse($"An error occurred while saving Appointment: {e.Message} ");
            }
        }

        public async Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found.");
            existingAppointment.PsychoNotes = appointment.PsychoNotes;
            existingAppointment.ScheduleDate = appointment.ScheduleDate;
            existingAppointment.Motive = appointment.Motive;
            existingAppointment.PersonalHistory = appointment.PersonalHistory;
            existingAppointment.TestRealized = appointment.TestRealized;
            existingAppointment.Treatment = appointment.Treatment;
            try
            {
                _appointmentRepository.Update(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch(Exception e)
            {
                return new AppointmentResponse($"An error occurred while updating the Appointment: {e.Message}");

            }
        }

        public async Task<AppointmentResponse> DeleteAsync(int id)
        {
            var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found.");

            try
            {
                _appointmentRepository.Remove(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch(Exception e)
            {
                return new AppointmentResponse($"An error occurred while deleting the Appointment: {e.Message}");
            }
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _appointmentRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetByPsychologistIdAsync(int id)
        {
            return await _appointmentRepository.FindAppointmentsByPsychologistIdAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int id)
        {
            return await _appointmentRepository.FindAppointmentsByPatientIdAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatientsByPsychologistIdAsync(int id)
        {
            return await _appointmentRepository.FindPatientsByPsychologistIdAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByPatientAndPsychologistIdAsync(int patientId, int psychologistId)
        {
            return await _appointmentRepository.FindByPatientAndPsychologistIdAsync(patientId, psychologistId);
        }
    }
}