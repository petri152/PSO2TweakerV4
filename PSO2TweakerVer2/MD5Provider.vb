Imports System
Imports System.IO
Imports System.Runtime.InteropServices

Public NotInheritable Class Md5Provider
    Implements IDisposable

    Private ReadOnly _bufferSize As Integer
    Private ReadOnly _hProv As IntPtr = IntPtr.Zero
    Private ReadOnly _buffer As Byte()

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptAcquireContext(ByRef hProv As IntPtr, ByVal pszContainer As String, ByVal pszProvider As String, ByVal dwProvType As UInteger, ByVal dwFlags As UInteger) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptCreateHash(ByVal hProv As IntPtr, ByVal algId As UInteger, ByVal hKey As IntPtr, ByVal dwFlags As UInteger, ByRef phHash As IntPtr) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptDestroyHash(ByVal hHash As IntPtr) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptGetHashParam(ByVal hHash As IntPtr, ByVal dwParam As Integer, ByVal pbData As Byte(), ByRef pdwDataLen As Integer, ByVal dwFlags As UInteger) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptHashData(ByVal hHash As IntPtr, ByVal pbData As Byte(), ByVal dataLen As Integer, ByVal flags As UInteger) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function CryptReleaseContext(ByVal hProv As IntPtr, ByVal dwFlags As Integer) As Boolean
    End Function

    Public Sub New(Optional ByVal bufferSize As Integer = &H1000)
        _bufferSize = bufferSize
        _buffer = New Byte(_bufferSize - 1) {}
        CryptAcquireContext(_hProv, Nothing, Nothing, 1, &HF0000000UI)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        CryptReleaseContext(_hProv, 0)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function ComputeHash(ByVal stream As Stream) As Byte()
        Dim hHash As IntPtr = IntPtr.Zero
        CryptCreateHash(_hProv, &H8003, IntPtr.Zero, 0, hHash)
        Dim bytesRead As Integer = stream.Read(_buffer, 0, _bufferSize)

        While bytesRead > 0
            CryptHashData(hHash, _buffer, bytesRead, 0)
            bytesRead = stream.Read(_buffer, 0, _bufferSize)
        End While

        Dim hash(15) As Byte
        CryptGetHashParam(hHash, 2, hash, 16, 0)
        CryptDestroyHash(hHash)

        Return hash
    End Function
End Class