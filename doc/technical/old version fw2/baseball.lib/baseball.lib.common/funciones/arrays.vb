Namespace funciones
    'TODO: A erradicar! UOOO! - Calculo, interseccion y demas historias con los arrays
    <Obsolete("Hay que intentar evitar el uso de esta clase en VS 2005. Suplía carencias del pasado")> _
    Public MustInherit Class Arrays
        Public Shared Sub ArrayToDataView(ByVal arr As Object(), ByRef dv As DataView, ByVal typeObjofArray As Type)
            Try

                'Obtenemos el tipo de la clase y sus propiedades //Reflexion
                Dim type As Type
                type = typeObjofArray

                Dim propiedades As Reflection.PropertyInfo()
                propiedades = type.GetProperties

                'Creamos una tabla -necesario para el dataview-
                Dim dt As New DataTable(type.Name)

                'Creamos las columnas de la tabla
                For Each p As Reflection.PropertyInfo In propiedades
                    dt.Columns.Add(p.Name, p.PropertyType)
                Next

                'Añadimos las filas
                If Not (arr Is Nothing) Then
                    For i As Integer = 0 To arr.Length - 1
                        Dim fila As String()
                        ReDim fila(dt.Columns.Count - 1)

                        Dim j As Integer = 0
                        For Each p As Reflection.PropertyInfo In propiedades
                            fila(j) = Convert.ToString(p.GetValue(arr(i), Nothing))
                            j += 1
                        Next

                        dt.Rows.Add(fila)
                    Next
                End If
                'Creamos el dataview
                dv = New DataView(dt)
                dv.AllowDelete = False
                dv.AllowEdit = False
                dv.AllowNew = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Shared Sub DataRowToObject(ByVal dr As DataRow, ByRef obj As Object)
            Try
                Dim type As Type

                type = obj.GetType()

                For Each col As DataColumn In dr.Table.Columns
                    If (type.GetProperty(col.ColumnName).CanWrite) Then
                        type.GetProperty(col.ColumnName).SetValue(obj, dr(col.ColumnName), Nothing)
                    End If
                Next

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ArrayExclude(ByVal aSet As Object(), ByVal aSubSet As Object(), ByRef aRes As Object()) As Object()
            Try
                If ((aSet Is Nothing) OrElse (aSet.Length = 0)) OrElse ((aSubSet Is Nothing) OrElse (aSubSet.Length = 0)) Then
                    Return aSet
                End If

                'Dim res As Object()
                Dim i As Integer = 0
                For Each obj As Object In aSet
                    If Not (ArrayContains(aSubSet, obj)) Then
                        ReDim Preserve aRes(i)
                        'aRes(i) = Activator.CreateInstance(aSet(0).GetType)
                        aRes(i) = obj
                        i += 1
                    End If
                Next
                Return aRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function ArrayIntersection(ByVal aSetA As Object(), ByVal aSetB As Object(), ByRef aResIntersection As Object()) As Object()
            Try
                If ((aSetA Is Nothing) OrElse (aSetA.Length = 0)) OrElse ((aSetB Is Nothing) OrElse (aSetB.Length = 0)) Then
                    Return Nothing
                End If

                'Dim res As Object()
                Dim i As Integer = 0
                For Each obj As Object In aSetA
                    If (ArrayContains(aSetB, obj)) Then
                        ReDim Preserve aResIntersection(i)
                        'aRes(i) = Activator.CreateInstance(aSet(0).GetType)
                        aResIntersection(i) = obj
                        i += 1
                    End If
                Next
                Return aResIntersection
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function ArrayContains(ByVal aSet As Object(), ByVal obj As Object) As Boolean
            Try
                Dim res As Boolean = False

                If Not (aSet Is Nothing) AndAlso Not (obj Is Nothing) Then
                    For Each o As Object In aSet
                        If (isEqual(o, obj)) Then
                            res = True
                            Exit For
                        End If
                    Next
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function isEqual(ByVal obj1 As Object, ByVal obj2 As Object) As Boolean
            Try
                Dim res As Boolean = False

                If ((obj1 Is Nothing) Or (obj2 Is Nothing)) Then
                    Return ((obj1 Is Nothing) And (obj2 Is Nothing))
                End If

                If (obj1.GetType Is obj2.GetType) Then

                    Dim type As Type = obj1.GetType

                    Dim aProperty As Reflection.PropertyInfo()
                    aProperty = type.GetProperties()

                    res = True
                    For Each p As Reflection.PropertyInfo In aProperty
                        If (p.PropertyType.IsValueType Or p.PropertyType.IsEnum Or p.PropertyType.Equals(GetType(String))) Then
                            Try
                                res = CBool(p.GetValue(obj1, Nothing) = p.GetValue(obj2, Nothing))
                            Catch ex As Exception
                                Try
                                    res = CBool(obj1 = obj2)
                                Catch ex2 As Exception
                                    res = (isEqual(p.GetValue(obj1, Nothing), p.GetValue(obj2, Nothing)))
                                End Try
                            End Try
                        Else
                            If Not (isEqual(p.GetValue(obj1, Nothing), p.GetValue(obj2, Nothing))) Then
                                res = False
                            End If
                        End If
                        If Not res Then
                            Return res
                            Exit For
                        End If
                    Next
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function ArrayToHashTable(ByVal aSet As Object(), ByVal keyName As String) As Hashtable
            Try
                Dim res As Hashtable = Nothing

                If Not (aSet Is Nothing) Then
                    res = New Hashtable
                    For Each obj As Object In aSet
                        res.Add(obj.GetType().GetProperty(keyName).GetValue(obj, Nothing), obj)
                    Next
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace