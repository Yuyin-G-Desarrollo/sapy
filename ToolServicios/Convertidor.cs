using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolServicios
{
    public class Convertidor<T> where T : new()
    {
        public DataTable ListToDataTable(List<T> data)
        {
            DataTable tabla = new DataTable();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public List<T> DataTableToList(DataTable tabla)
        {
            List<T> lista = new List<T>();
            T clase;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Type tipoDato = typeof(T);
                clase = new T();
                foreach (PropertyInfo propiedades in tipoDato.GetProperties())
                {
                    propiedades.SetValue(clase, ValorPorDefault(tabla.Rows[i][propiedades.Name]), null);
                }
                lista.Add(clase);
            }
            return lista;
        }

        public T DataTableToClase(DataTable tabla)
        {
            T clase = new T();

            Type tipoDato = typeof(T);
            clase = new T();
            foreach (PropertyInfo propiedades in tipoDato.GetProperties())
            {
                propiedades.SetValue(clase, ValorPorDefault(tabla.Rows[0][propiedades.Name]), null);
            }


            return clase;
        }

        private object ValorPorDefault(object tipo)
        {
            if (tipo == System.DBNull.Value)
            {
                return "";
            }
            else
            {
                return tipo;
            }
        }
        public object[] DataTableToArray(int encabezado, DataTable tabla)
        {
            object[] nombreColumnas = new object[tabla.Columns.Count];
            object[] tipoDatos = new object[tabla.Columns.Count];
            int filasPorEncabezado = 0;
            if (encabezado == 0)
            {
                filasPorEncabezado += 2;
            }
            object[] general = new object[((tabla.Rows.Count) + filasPorEncabezado)];

            if (encabezado == 0)
            {
                for (int i = 0; i <= tabla.Columns.Count - 1; i++)
                {
                    nombreColumnas[i] = tabla.Columns[i].ColumnName;
                    tipoDatos[i] = tabla.Columns[i].DataType.FullName;
                }
                general[0] = nombreColumnas;
                general[1] = tipoDatos;
                for (int n = 0; n < tabla.Rows.Count; n++)
                {
                    general[n + 2] = tabla.Rows[n].ItemArray;
                }
            }
            else
            {
                for (int n = 0; n < tabla.Rows.Count - 1; n++)
                {
                    general[n] = tabla.Rows[n].ItemArray;
                }
            }
            return general;
        }

        public DataTable ArrayToDataTable(object[] arreglo)
        {
            DataTable tabla = new DataTable();


            for (int i = 0; i <= arreglo.Length - 1; i++)
            {
                if (i == 0)
                {
                    object[] Columnas = (object[])arreglo[0];
                    object[] Tipos = (object[])arreglo[1];
                    for (int m = 0; m <= Columnas.Length - 1; m++)
                    {
                        DataColumn col = new DataColumn();
                        col.ColumnName = Columnas[m].ToString();
                        System.Type tipoCol = System.Type.GetType(Tipos[m].ToString());
                        col.DataType = tipoCol;
                        tabla.Columns.Add(col);
                    }
                }
                if (i > 1)
                {
                    DataRow row = tabla.NewRow();
                    object[] Fila = (object[])arreglo[i];
                    for (int n = 0; n < tabla.Columns.Count; n++)
                    {
                        if (Fila[n] == null)
                        {
                            row[n] = DBNull.Value;
                        }
                        else
                        {
                            row[n] = Fila[n];
                        }

                    }
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }
    }
}
