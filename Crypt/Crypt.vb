
Public Class Crypt
    ''' <summary>
    ''' Encrypt a string
    ''' </summary>
    Public Shared Function Encrypt(ByVal source As String, ByVal theKey As Integer) As String
        Dim counter As Integer
        Dim jumbleMethod As New Random(theKey)
        Dim keySet(source.Length - 1) As Byte
        Dim sourceBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(source)

        jumbleMethod.NextBytes(keySet)
        For counter = 0 To sourceBytes.Length - 1
            sourceBytes(counter) = sourceBytes(counter) Xor keySet(counter)
        Next counter

        Return Convert.ToBase64String(sourceBytes)
    End Function
    ''' <summary>
    '''Decrypt a previously encrypted string.
    ''' </summary>
    Public Shared Function Decrypt(ByVal source As String, ByVal theKey As Integer) As String
        Dim counter As Integer
        Dim jumbleMethod As New Random(theKey)
        Dim sourceBytes() As Byte = Convert.FromBase64String(source)
        Dim keySet(sourceBytes.Length - 1) As Byte

        jumbleMethod.NextBytes(keySet)
        For counter = 0 To sourceBytes.Length - 1
            sourceBytes(counter) = sourceBytes(counter) Xor keySet(counter)
        Next counter

        Return System.Text.Encoding.UTF8.GetString(sourceBytes)
    End Function
End Class

