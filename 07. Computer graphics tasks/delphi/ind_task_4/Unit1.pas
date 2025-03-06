unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, OpenGL;

type
    TForm1 = class(TForm)
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure FormPaint(Sender: TObject);
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure FormResize(Sender: TObject);
  private
    { Private declarations }
    hrc: HGLRC;  { ���: ���  - ������ �� �������� ���������������}
    DC: HDC;
    pos:array[0..3] of GLfloat;

  public
    { Public declarations }
  end;

  const light_ambient:array[0..3] of GLfloat = ( 0.0, 0.0, 0.0, 1.0 );
  light_diffuse:array[0..3] of GLfloat = ( 1.0, 1.0, 1.0, 1.0 );

var
  Form1: TForm1;
  i: Integer;
  j:Integer;
  choice: Integer;
  obj: (TETRAHEDRON, ICOSAHEDRON, DODECAHEDRON, CUBE, SPHERE, CONE, TORUS, TEAPOT) = CUBE;
  mode: (POINT, LINE, FILL) = FILL; // ����� ����������� ��������
  x_1: Extended;
  z_1: Extended;

  pos1:array[0..3] of GLfloat =(3,0,0,1);
implementation

uses dglut;

{$R *.dfm}

procedure SetDCPixelFormat (hdc: HDC);
var pfd: TPixelFormatDescriptor;
    nPixelFormat: Integer;
begin
    FillChar(pfd, SizeOf(pfd),0);
    pfd.dwFlags:=PFD_SUPPORT_OPENGL or PFD_DRAW_TO_WINDOW or PFD_DOUBLEBUFFER;
    nPixelFormat:=ChoosePixelFormat (hdc,@pfd);
    SetPixelFormat(hdc,nPixelFormat,@pfd);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
DC:=GetDC(Handle); // �������� ������ ������ �� �������� ����������
SetDCPixelFormat(DC);  // ������ ������ �������
hrc:=wglCreateContext(DC);  // ������� �������� ���������������
wglMakeCurrent(DC, hrc);
glClearColor(0.1,0.1,0.15,0);
glMatrixMode(GL_PROJECTION);
glEnable(GL_DEPTH_TEST);

glEnable(GL_LIGHTING); // �������� ����
glEnable(GL_LIGHT0);  // ��� �������� ����

// ��������� ��������� ��������� �����
pos[0]:= 0.0;
pos[1]:= 1.0;
pos[2]:= -4.0;
pos[3]:= 1.0;
// ���������� �������� � ������� pos
glLightfv(GL_LIGHT0, GL_POSITION, @pos);
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
wglMakeCurrent(0, 0);
wglDeleteContext(hrc);  // ������������ ��������� ���������������
ReleaseDC(Handle, DC);
DeleteDC(DC);
end;

procedure TForm1.FormPaint(Sender: TObject);
begin
glClear(GL_COLOR_BUFFER_BIT or GL_DEPTH_BUFFER_BIT); // ������� ������ �����

// ���������

glPushMatrix;
glTranslatef(-2,0,0);
glutSolidSphere(0.4, 50, 50);
glPopMatrix;

glPushMatrix;
glTranslatef(-1,0,0);
glutSolidSphere(0.6, 50, 50);
glPopMatrix;

glLightfv(GL_LIGHT0, GL_POSITION, @pos);  // ������� ����� ��������
SwapBuffers(DC); // ����� ����������� ������ �� �����
wglMakeCurrent(dc,hrc); // ���������� ��������
//glTranslatef(-x1, -y1, 0);
end;

procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if key=VK_SPACE then InvalidateRect(handle,nil,false);
// ��������� ��Z => ������ ������ pos[0] - x, pos[3] - z
// ����� �������� ������ ����������: x = z^2 - 4.
// �� ���� �� ���� �� ��� ���, � ������� ��������� z^2
// ��������� ����� - (0.0, 1.0, -4.0, 1.0)
// ��������� �������� - v, ������ �� �������� ����� � ������������� (0 - ��, 1 - ���)
// �������� ��������� ����� �� �������� � ���� �������
if key=VK_F1 then
  pos[0]:= pos[0] - 0.5;  // ������� ����������
  pos[2]:= pos[0] * pos[0] - 4.0;  // ������� ����������
  Refresh;
// �������� ��������� ����� �� �������� � ���� �������
if key=VK_F2 then
  pos[0]:= pos[0] + 0.5;  // ������� ����������
  pos[2]:= pos[0] * pos[0] - 4.0;  // ������� ����������
  Refresh;
end;

procedure TForm1.FormResize(Sender: TObject);
begin
glViewPort(0,0,ClientWidth,ClientHeight); // ������� ������
glMatrixMode(GL_PROJECTION);
glLoadIdentity; // ��� ������� � �������� ���������
glFrustum(-1, 1, -1, 1, 3, 10); // ������� ��������� - ������������� ��������
glTranslatef(0.0, 0.0, -8.0); // ��������� ����� ������� ���������
glRotatef(30,1,0,0);    // ����� �������
glRotatef(70,0,1,0);    // ������������
glMatrixMode(GL_MODELVIEW);
end;

end.
