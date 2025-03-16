CREATE PROCEDURE [dbo].[GetAvailableAppointments]
    @IdMedico INT,
    @Fecha DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @date datetime = @Fecha
   
    SELECT HoraInicio, @date as hoy, cita.Hora
    FROM Agenda 
    left join cita 
        on cita.Idpsicologo = Agenda.Idpsicologo
        and cita.Hora = agenda.HoraInicio
        and cita.fecha =  @Fecha
    where 
        anio = YEAR(@date) and cita.Hora is null 
    order by
	    DiaSemana, Agenda.HoraInicio
END;