using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Conformidad.Models
{
    public class Comprobantes
    {

        public class Rootobject
        {
            public int cntTotalReg { get; set; }
            public int numPag { get; set; }
            public int numRegPag { get; set; }
            public int numDiasAtencionMax { get; set; }
            public int numDiasAtencionMaxAdic { get; set; }
            public Numeropagina[] numeroPaginas { get; set; }
            public Comprobante[] comprobantes { get; set; }
        }

        public class Numeropagina
        {
            public int numPagFront { get; set; }
        }

        public class Comprobante
        {
            public string codCpe { get; set; }
            public string numSerie { get; set; }
            public int numCpe { get; set; }
            public string codMoneda { get; set; }
            public Datosemisor datosEmisor { get; set; }
            public Datosreceptor datosReceptor { get; set; }
            public Procedenciaindividual procedenciaIndividual { get; set; }
            public Procedenciamasiva procedenciaMasiva { get; set; }
            public DateTime fecEmision { get; set; }
            public object fecVencimiento { get; set; }
            public DateTime fecRegistro { get; set; }
            public DateTime fecPuestaDisposicion { get; set; }
            public string codTipTransaccion { get; set; }
            public int numDiasAtencion { get; set; }
            public string indEstadoCpe { get; set; }
            public string indProcedencia { get; set; }
            public string indTituloGratuito { get; set; }
            public object datosRHE { get; set; }
            public Transaccione[] transacciones { get; set; }
            public Datodocrelacionado datoDocRelacionado { get; set; }
            public Eventosmovimiento[] eventosMovimiento { get; set; }
            public Auditoria auditoria { get; set; }
            public object notasCpe { get; set; }
        }

        public class Datosemisor
        {
            public string numRuc { get; set; }
            public string desRazonSocialEmis { get; set; }
        }

        public class Datosreceptor
        {
            public string codDocIdeRecep { get; set; }
            public string numDocIdeRecep { get; set; }
            public string desRazonSocialRecep { get; set; }
        }

        public class Procedenciaindividual
        {
            public float? mtoSubTotalVentas { get; set; }
            public object mtoAnticipos { get; set; }
            public object mtoDtos { get; set; }
            public float? mtoValorVenta { get; set; }
            public object mtoISC { get; set; }
            public float? mtoIGV { get; set; }
            public object mtoICBPER { get; set; }
            public object mtoOtrosCargos { get; set; }
            public object mtoOtrosTributos { get; set; }
            public float? mtoImporteTotal { get; set; }
        }

        public class Procedenciamasiva
        {
            public object mtoDtoGlobalAfecBI { get; set; }
            public float? mtoTotalValVentaGrabado { get; set; }
            public float? mtoTotalValVentaInafecto { get; set; }
            public float? mtoTotalValVentaExonerado { get; set; }
            public float? mtoTotalValVentaGratuito { get; set; }
            public object mtoTotalValVentaExportacion { get; set; }
            public object mtoDtoGlobalNoAfecBI { get; set; }
            public object mtoTotalDtos { get; set; }
            public object mtoSumOtrosTributos { get; set; }
            public object mtoSumOtrosCargos { get; set; }
            public object mtoSumISC { get; set; }
            public float? mtoSumIGV { get; set; }
            public object mtoSumICBPER { get; set; }
            public float? mtoTotalAnticipo { get; set; }
            public float? mtoImporteTotal { get; set; }
        }

        public class Datodocrelacionado
        {
            public object codTipNota { get; set; }
            public object desMotivo { get; set; }
            public object documentosModifica { get; set; }
            public object documentosRelacionado { get; set; }
        }

        public class Auditoria
        {
            public string codUsuRegis { get; set; }
            public DateTime fecRegis { get; set; }
            public string codUsuModif { get; set; }
            public DateTime fecModif { get; set; }
        }

        public class Transaccione
        {
            public string codCpeTransaccion { get; set; }
            public string numSerieTransaccion { get; set; }
            public int numCpeTransaccion { get; set; }
            public float mtoPagoPendiente { get; set; }
            public DateTime fecPlazoPago { get; set; }
            public DateTime fecEmisionTransaccion { get; set; }
            public int numCuotas { get; set; }
            public Cuota[] cuotas { get; set; }
        }

        public class Cuota
        {
            public string numCuota { get; set; }
            public float mtoCuota { get; set; }
            public DateTime fecVencimiento { get; set; }
            public object pagos { get; set; }
        }

        public class Eventosmovimiento
        {
            public int numMovimiento { get; set; }
            public DateTime fecModificacion { get; set; }
            public object desComentario { get; set; }
            public object indProcedencia { get; set; }
            public object desUsuRegis { get; set; }
            public Condicioncomprobante condicionComprobante { get; set; }
            public object disconformidad { get; set; }
            public object subsanaciones { get; set; }
            public object baja { get; set; }
        }

        public class Condicioncomprobante
        {
            public string codEstadoCondicion { get; set; }
            public string codCondicion { get; set; }
            public string codMarcaCondicion { get; set; }
            public string codEfectoCredFiscal { get; set; }
            public string codEfectoFactoring { get; set; }
            public string codEvento { get; set; }
        }

    }
}