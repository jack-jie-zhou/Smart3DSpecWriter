# SP3DSpecWriter

## C1. Project

### C1.1. CodelistControl

1. Template: `Windows Forms Control Library (.NET Framework)`
2. Target: `.NET Framework 4.8`
3. `Dapper` 2.1.35
4. `System.Data.SQLite` 1.0.119

### C1.2. SP3DSpecWriter

1. Project Template `Excel VSTO Add-in`
2. Target `.NET Framework 4.8`






---









# Errors

### E.1. SQLite.Interop.dll

![image](https://github.com/user-attachments/assets/c9c7c024-a8ab-4b39-9ff9-7dc045e5eae2)

#### Solution

1. Add SQLite.Interop.dll to the project
2. Set the File properties of these two file: `Copy to Output Directory = Copy always`

![image](https://github.com/user-attachments/assets/409df7e7-272d-42cb-9645-02b2b2b49bbc)

```bash
# for X64
C:\20241010 CommodityCodeBuilder\packages\Stub.System.Data.SQLite.Core.NetFramework.1.0.119.0\build\net451\x64\SQLite.Interop.dll 
(1941KB)

# for X86
C:\20241010 CommodityCodeBuilder\packages\Stub.System.Data.SQLite.Core.NetFramework.1.0.119.0\build\net451\x86\SQLite.Interop.dll 
(1595KB)
```
