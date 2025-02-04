import re

def convert_vbnet_to_csharp(vb_code):
    replacements = [
        (r'(?i)Dim (\w+) As Integer', r'int \1'),
        (r'(?i)Dim (\w+) As String', r'string \1'),
        (r'(?i)Dim (\w+) As Boolean', r'bool \1'),
        (r'(?i)Dim (\w+) As Double', r'double \1'),
        (r'(?i)Dim (\w+) As Object', r'object \1'),
        (r'(?i)Dim (\w+) As New (\w+)', r'\2 \1 = new \2()'),
        (r'(?i)If (.+) Then', r'if (\1) {'),
        (r'(?i)ElseIf (.+) Then', r'} else if (\1) {'),
        (r'(?i)Else', r'} else {'),
        (r'(?i)End If', r'}'),
        (r'(?i)For (\w+) As Integer = (\d+) To (\d+)', r'for (int \1 = \2; \1 <= \3; \1++) {'),
        (r'(?i)Next', r'}'),
        (r'(?i)While (.+)', r'while (\1) {'),
        (r'(?i)End While', r'}'),
        (r'(?i)Do While (.+)', r'while (\1) {'),
        (r'(?i)Loop', r'}'),
        (r'(?i)Try', r'try {'),
        (r'(?i)Catch (\w+) As Exception', r'} catch (Exception \1) {'),
        (r'(?i)Finally', r'} finally {'),
        (r'(?i)End Try', r'}'),
        (r'(?i)Sub (\w+)\(\)', r'void \1() {'),
        (r'(?i)Function (\w+)\((.*?)\) As (\w+)', r'\3 \1(\2) {'),
        (r'(?i)End Sub', r'}'),
        (r'(?i)End Function', r'}'),
        (r'(?i)Select Case (.+)', r'switch (\1) {'),
        (r'(?i)Case (.+)', r'case \1:'),
        (r'(?i)Case Else', r'default:'),
        (r'(?i)End Select', r'}'),
        (r'(?i)Me\.', r'this.'),
        (r'(?i)MsgBox\((.+)\)', r'MessageBox.Show(\1);'),
        (r'(?i)Imports (.+)', r'using \1;'),
        (r'(?i)Namespace (.+)', r'namespace \1 {'),
        (r'(?i)End Namespace', r'}'),
        (r'(?i)Nothing', r'null'),
        (r'(?i)Not', r'!'),
        (r'(?i)AndAlso', r'&&'),
        (r'(?i)OrElse', r'||')
    ]
    
    for pattern, replacement in replacements:
        vb_code = re.sub(pattern, replacement, vb_code)
    
    return vb_code

# Example usage
vb_code = """
Dim x As Integer = 10
Dim str As String = "Hello"
If x > 5 Then
    MsgBox("X is greater than 5")
Else
    MsgBox("X is not greater than 5")
End If
"""

csharp_code = convert_vbnet_to_csharp(vb_code)
print(csharp_code)
