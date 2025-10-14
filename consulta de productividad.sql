select 
	NumeroFactura, 
	paciente.id,
	psicologo.id,
	Total,
	[Factura].estado
from [Factura]
inner join paciente on paciente.id = [Factura].idPaciente
inner join psicologo on psicologo.id = [Factura].IdPsicologo
inner join (select sum(Monto) as total, FacturaId from pagos ) as pagos_psicologo on 
   pagos_psicologo.FacturaId = [Factura].Id   
where [Factura].Estado = 1

/*
hacer una sub consulta que sume todos los pagos que se le han hecho al psicologo
por factura 
*/

select  * from facturas
select sum(Monto) as total, FacturaId from pagos where FacturaId = 1
CREATE TABLE Pagos (
    Id int PRIMARY KEY identity(1, 1),
    PsicologoId int NOT NULL,
    FacturaId int NOT NULL,
    TipoPago VARCHAR(20) NOT NULL, -- 'SESION_INDIVIDUAL' o 'PAQUETE'
    PaqueteId int NULL, -- Solo si es paquete
    NumeroSesion INT NULL, -- Número de sesión dentro del paquete (ej: 1, 2, 3)
    Monto DECIMAL(18, 2) NOT NULL,
    FechaPago DATETIME NOT NULL,
    Estado VARCHAR(20) NOT NULL, -- 'PENDIENTE', 'PAGADO', 'RECHAZADO'
    CONSTRAINT FK_Pagos_Psicologos FOREIGN KEY (PsicologoId) REFERENCES Psicologo(Id),
    CONSTRAINT FK_Pagos_Facturas FOREIGN KEY (FacturaId) REFERENCES Factura(Id),
    CONSTRAINT FK_Pagos_Paquetes FOREIGN KEY (PaqueteId) REFERENCES Paquete(Id)
);