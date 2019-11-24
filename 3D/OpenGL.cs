using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using DevExpress.XtraCharts.Native;

namespace DevExpress.XtraCharts.GLGraphics {
    [CLSCompliant(false)]
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class GLImport_Win {
        const string OpenGL32 = "opengl32.dll";

        [DllImport(OpenGL32, EntryPoint = "glFinish")]
        public static extern void Finish();
        [DllImport(OpenGL32, EntryPoint = "glEnable")]
        public static extern void Enable(int cap);
        [DllImport(OpenGL32, EntryPoint = "glDisable")]
        public static extern void Disable(int cap);
        [DllImport(OpenGL32, EntryPoint = "glGetIntegerv")]
#if DEBUGTEST //DEMO_REMOVE   
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetIntegerv(int pname, [Out] int[] param);
        [DllImport(OpenGL32, EntryPoint = "glGetDoublev")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static extern void GetDoublev(int pname, [Out] double[] param);
        [DllImport(OpenGL32, EntryPoint = "glClearColor")]
        public static extern void ClearColor(float red, float green, float blue, float alpha);
        [DllImport(OpenGL32, EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc(int func);
        [DllImport(OpenGL32, EntryPoint = "glClearDepth")]
        public static extern void ClearDepth(float depth);
        [DllImport(OpenGL32, EntryPoint = "glClearStencil")]
        public static extern void ClearStencil(int s);
        [DllImport(OpenGL32, EntryPoint = "glClear")]
        public static extern void Clear(int mask);
        [DllImport(OpenGL32, EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int width, int height);
        [DllImport(OpenGL32, EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode(int mode);
        [DllImport(OpenGL32, EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix();
        [DllImport(OpenGL32, EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix();
        [DllImport(OpenGL32, EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity();
        [DllImport(OpenGL32, EntryPoint = "glLoadMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LoadMatrixd([In] double[] m);
        [DllImport(OpenGL32, EntryPoint = "glMultMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void MultMatrixd([In] double[] m);
        [DllImport(OpenGL32, EntryPoint = "glTranslated")]
        public static extern void Translated(double x, double y, double z);
        [DllImport(OpenGL32, EntryPoint = "glRotated")]
        public static extern void Rotated(double angle, double x, double y, double z);
        [DllImport(OpenGL32, EntryPoint = "glScaled")]
        public static extern void Scaled(double x, double y, double z);
        [DllImport(OpenGL32, EntryPoint = "glOrtho")]
        public static extern void Ortho(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport(OpenGL32, EntryPoint = "glFrustum")]
        public static extern void Frustum(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport(OpenGL32, EntryPoint = "glBegin")]
        public static extern void Begin(int mode);
        [DllImport(OpenGL32, EntryPoint = "glEnd")]
        public static extern void End();
        [DllImport(OpenGL32, EntryPoint = "glColor4f")]
        public static extern void Color4f(float read, float green, float blue, float alpha);
        [DllImport(OpenGL32, EntryPoint = "glColor4b")]
        public static extern void Color4b(byte read, byte green, byte blue, byte alpha);
        [DllImport(OpenGL32, EntryPoint = "glColor4ub")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Color4ub(byte read, byte green, byte blue, byte alpha);
        [DllImport(OpenGL32, EntryPoint = "glVertex3d")]
        public static extern void Vertex3d(double x, double y, double z);
        [DllImport(OpenGL32, EntryPoint = "glNormal3f")]
        public static extern void Normal3f(float nx, float ny, float nz);
        [DllImport(OpenGL32, EntryPoint = "glNormal3d")]
        public static extern void Normal3d(double nx, double ny, double nz);
        [DllImport(OpenGL32, EntryPoint = "glEdgeFlag")]
        public static extern void EdgeFlag(int flag);
        [DllImport(OpenGL32, EntryPoint = "glLineStipple")]
        public static extern void LineStipple(int factor, ushort pattern);
        [DllImport(OpenGL32, EntryPoint = "glLineWidth")]
        public static extern void LineWidth(float width);
        [DllImport(OpenGL32, EntryPoint = "glPointSize")]
        public static extern void PointSize(float size);
        [DllImport(OpenGL32, EntryPoint = "glClipPlane")]
        public static extern void ClipPlane(int plane, [In] double[] equation);
        [DllImport(OpenGL32, EntryPoint = "glShadeModel")]
        public static extern void ShadeModel(int mode);
        [DllImport(OpenGL32, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc(int sfactor, int dfactor);
        [DllImport(OpenGL32, EntryPoint = "glLightModeli")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModeli(int pname, int param);
        [DllImport(OpenGL32, EntryPoint = "glLightModelfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModelfv(int pname, float[] param);
        [DllImport(OpenGL32, EntryPoint = "glLightf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightf(int light, int pname, float param);
        [DllImport(OpenGL32, EntryPoint = "glLightfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightfv(int light, int pname, [In] float[] param);
        [DllImport(OpenGL32, EntryPoint = "glColorMaterial")]
        public static extern void ColorMaterial(int face, int mode);
        [DllImport(OpenGL32, EntryPoint = "glMaterialf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialf(int face, int pname, float param);
        [DllImport(OpenGL32, EntryPoint = "glMaterialfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialfv(int face, int pname, [In] float[] param);
        [DllImport(OpenGL32, EntryPoint = "glPixelStorei")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void PixelStorei(int pname, int param);
        [DllImport(OpenGL32, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, [In] float[] pixels);
        [DllImport(OpenGL32, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels);
        [DllImport(OpenGL32, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);
        [DllImport(OpenGL32, EntryPoint = "glTexCoord1f")]
        public static extern void TexCoord1f(float f);
        [DllImport(OpenGL32, EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2f(float s, float t);
        [DllImport(OpenGL32, EntryPoint = "glTexCoord2d")]
        public static extern void TexCoord2d(double s, double t);
        [DllImport(OpenGL32, EntryPoint = "glGenTextures")]
        public static extern void GenTextures(int n, [Out] uint[] textures);
        [DllImport(OpenGL32, EntryPoint = "glDeleteTextures")]
        public static extern void DeleteTextures(int n, [Out] uint[] textures);
        [DllImport(OpenGL32, EntryPoint = "glBindTexture")]
        public static extern void BindTexture(int target, uint texture);
        [DllImport(OpenGL32, EntryPoint = "glTexParameteri")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexParameteri(int target, int pname, int param);
        [DllImport(OpenGL32, EntryPoint = "glTexEnvf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexEnvf(int target, int pname, float param);
        [DllImport(OpenGL32, EntryPoint = "glHint")]
        public static extern void Hint(int target, int mode);
        [DllImport(OpenGL32, EntryPoint = "glStencilOp")]
        public static extern void StencilOp(int fail, int zfail, int zpass);
        [DllImport(OpenGL32, EntryPoint = "glStencilFunc")]
        public static extern void StencilFunc(int func, int refer, uint mask);
        [DllImport(OpenGL32, EntryPoint = "glAccum")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Accum(int operation, float val);
        [DllImport(OpenGL32, EntryPoint = "glClearAccum")]
        public static extern void ClearAccum(float red, float green, float blue, float alpha);
        [DllImport(OpenGL32, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, int format, int type, [Out] byte[] pixels);
        [DllImport(OpenGL32, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, int format, int type, [Out] IntPtr pixels);
        [DllImport(OpenGL32, EntryPoint = "glDrawPixels")]
        public static extern void DrawPixels(int width, int height, int format, int type, [In] byte[] pixels);
        [DllImport(OpenGL32, EntryPoint = "glRasterPos2i")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void RasterPosi(int x, int y);
        [DllImport(OpenGL32, EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer(int mode);
        [DllImport(OpenGL32, EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer(int mode);
        [DllImport(OpenGL32, EntryPoint = "glPolygonOffset")]
        public static extern void PolygonOffset(float factor, float units);
        [DllImport(OpenGL32, EntryPoint = "glCullFace")]
        public static extern void CullFace(int mode);
        [DllImport(OpenGL32, EntryPoint = "glColorMask")]
        public static extern void ColorMask(bool red, bool green, bool blue, bool alpha);
        [DllImport(OpenGL32, EntryPoint = "glDepthMask")]
        public static extern void DepthMask(bool flag);
        [DllImport(OpenGL32, EntryPoint = "glGetBooleanv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetBooleanv(int pname, [Out] bool[] pars);
        [DllImport(OpenGL32, EntryPoint = "glGetError")]
        public static extern int GetError();
    }

    [CLSCompliant (false)]
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage ("SpellChecker", "CRRSP01")]
    public class GLImport_Linux {
        const string LibGL = "libGL.so.1";

        [DllImport (LibGL, EntryPoint = "glFinish")]
        public static extern void Finish ();
        [DllImport (LibGL, EntryPoint = "glEnable")]
        public static extern void Enable (int cap);
        [DllImport (LibGL, EntryPoint = "glDisable")]
        public static extern void Disable (int cap);
        [DllImport (LibGL, EntryPoint = "glGetIntegerv")]
#if DEBUGTEST //DEMO_REMOVE   
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetIntegerv (int pname, [Out] int [] param);
        [DllImport (LibGL, EntryPoint = "glGetDoublev")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static extern void GetDoublev (int pname, [Out] double [] param);
        [DllImport (LibGL, EntryPoint = "glClearColor")]
        public static extern void ClearColor (float red, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc (int func);
        [DllImport (LibGL, EntryPoint = "glClearDepth")]
        public static extern void ClearDepth (float depth);
        [DllImport (LibGL, EntryPoint = "glClearStencil")]
        public static extern void ClearStencil (int s);
        [DllImport (LibGL, EntryPoint = "glClear")]
        public static extern void Clear (int mask);
        [DllImport (LibGL, EntryPoint = "glViewport")]
        public static extern void Viewport (int x, int y, int width, int height);
        [DllImport (LibGL, EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode (int mode);
        [DllImport (LibGL, EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix ();
        [DllImport (LibGL, EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix ();
        [DllImport (LibGL, EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity ();
        [DllImport (LibGL, EntryPoint = "glLoadMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LoadMatrixd ([In] double [] m);
        [DllImport (LibGL, EntryPoint = "glMultMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void MultMatrixd ([In] double [] m);
        [DllImport (LibGL, EntryPoint = "glTranslated")]
        public static extern void Translated (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glRotated")]
        public static extern void Rotated (double angle, double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glScaled")]
        public static extern void Scaled (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glOrtho")]
        public static extern void Ortho (double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport (LibGL, EntryPoint = "glFrustum")]
        public static extern void Frustum (double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport (LibGL, EntryPoint = "glBegin")]
        public static extern void Begin (int mode);
        [DllImport (LibGL, EntryPoint = "glEnd")]
        public static extern void End ();
        [DllImport (LibGL, EntryPoint = "glColor4f")]
        public static extern void Color4f (float read, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glColor4b")]
        public static extern void Color4b (byte read, byte green, byte blue, byte alpha);
        [DllImport (LibGL, EntryPoint = "glColor4ub")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Color4ub (byte read, byte green, byte blue, byte alpha);
        [DllImport (LibGL, EntryPoint = "glVertex3d")]
        public static extern void Vertex3d (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glNormal3f")]
        public static extern void Normal3f (float nx, float ny, float nz);
        [DllImport (LibGL, EntryPoint = "glNormal3d")]
        public static extern void Normal3d (double nx, double ny, double nz);
        [DllImport (LibGL, EntryPoint = "glEdgeFlag")]
        public static extern void EdgeFlag (int flag);
        [DllImport (LibGL, EntryPoint = "glLineStipple")]
        public static extern void LineStipple (int factor, ushort pattern);
        [DllImport (LibGL, EntryPoint = "glLineWidth")]
        public static extern void LineWidth (float width);
        [DllImport (LibGL, EntryPoint = "glPointSize")]
        public static extern void PointSize (float size);
        [DllImport (LibGL, EntryPoint = "glClipPlane")]
        public static extern void ClipPlane (int plane, [In] double [] equation);
        [DllImport (LibGL, EntryPoint = "glShadeModel")]
        public static extern void ShadeModel (int mode);
        [DllImport (LibGL, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc (int sfactor, int dfactor);
        [DllImport (LibGL, EntryPoint = "glLightModeli")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModeli (int pname, int param);
        [DllImport (LibGL, EntryPoint = "glLightModelfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModelfv (int pname, float [] param);
        [DllImport (LibGL, EntryPoint = "glLightf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightf (int light, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glLightfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightfv (int light, int pname, [In] float [] param);
        [DllImport (LibGL, EntryPoint = "glColorMaterial")]
        public static extern void ColorMaterial (int face, int mode);
        [DllImport (LibGL, EntryPoint = "glMaterialf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialf (int face, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glMaterialfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialfv (int face, int pname, [In] float [] param);
        [DllImport (LibGL, EntryPoint = "glPixelStorei")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void PixelStorei (int pname, int param);
        [DllImport (LibGL, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D (int target, int level, int internalformat, int width, int border, int format, int type, [In] float [] pixels);
        [DllImport (LibGL, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D (int target, int level, int internalformat, int width, int height, int border, int format, int type, byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D (int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);
        [DllImport (LibGL, EntryPoint = "glTexCoord1f")]
        public static extern void TexCoord1f (float f);
        [DllImport (LibGL, EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2f (float s, float t);
        [DllImport (LibGL, EntryPoint = "glTexCoord2d")]
        public static extern void TexCoord2d (double s, double t);
        [DllImport (LibGL, EntryPoint = "glGenTextures")]
        public static extern void GenTextures (int n, [Out] uint [] textures);
        [DllImport (LibGL, EntryPoint = "glDeleteTextures")]
        public static extern void DeleteTextures (int n, [Out] uint [] textures);
        [DllImport (LibGL, EntryPoint = "glBindTexture")]
        public static extern void BindTexture (int target, uint texture);
        [DllImport (LibGL, EntryPoint = "glTexParameteri")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexParameteri (int target, int pname, int param);
        [DllImport (LibGL, EntryPoint = "glTexEnvf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexEnvf (int target, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glHint")]
        public static extern void Hint (int target, int mode);
        [DllImport (LibGL, EntryPoint = "glStencilOp")]
        public static extern void StencilOp (int fail, int zfail, int zpass);
        [DllImport (LibGL, EntryPoint = "glStencilFunc")]
        public static extern void StencilFunc (int func, int refer, uint mask);
        [DllImport (LibGL, EntryPoint = "glAccum")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Accum (int operation, float val);
        [DllImport (LibGL, EntryPoint = "glClearAccum")]
        public static extern void ClearAccum (float red, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels (int x, int y, int width, int height, int format, int type, [Out] byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels (int x, int y, int width, int height, int format, int type, [Out] IntPtr pixels);
        [DllImport (LibGL, EntryPoint = "glDrawPixels")]
        public static extern void DrawPixels (int width, int height, int format, int type, [In] byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glRasterPos2i")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void RasterPosi (int x, int y);
        [DllImport (LibGL, EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer (int mode);
        [DllImport (LibGL, EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer (int mode);
        [DllImport (LibGL, EntryPoint = "glPolygonOffset")]
        public static extern void PolygonOffset (float factor, float units);
        [DllImport (LibGL, EntryPoint = "glCullFace")]
        public static extern void CullFace (int mode);
        [DllImport (LibGL, EntryPoint = "glColorMask")]
        public static extern void ColorMask (bool red, bool green, bool blue, bool alpha);
        [DllImport (LibGL, EntryPoint = "glDepthMask")]
        public static extern void DepthMask (bool flag);
        [DllImport (LibGL, EntryPoint = "glGetBooleanv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetBooleanv (int pname, [Out] bool [] pars);
        [DllImport (LibGL, EntryPoint = "glGetError")]
        public static extern int GetError ();
    }

    [CLSCompliant (false)]
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage ("SpellChecker", "CRRSP01")]
    public class GLImport_OSMesa {
        const string LibGL = "libOSMesa.so.8";

        [DllImport (LibGL, EntryPoint = "glFinish")]
        public static extern void Finish ();
        [DllImport (LibGL, EntryPoint = "glEnable")]
        public static extern void Enable (int cap);
        [DllImport (LibGL, EntryPoint = "glDisable")]
        public static extern void Disable (int cap);
        [DllImport (LibGL, EntryPoint = "glGetIntegerv")]
#if DEBUGTEST //DEMO_REMOVE   
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetIntegerv (int pname, [Out] int [] param);
        [DllImport (LibGL, EntryPoint = "glGetDoublev")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static extern void GetDoublev (int pname, [Out] double [] param);
        [DllImport (LibGL, EntryPoint = "glClearColor")]
        public static extern void ClearColor (float red, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc (int func);
        [DllImport (LibGL, EntryPoint = "glClearDepth")]
        public static extern void ClearDepth (float depth);
        [DllImport (LibGL, EntryPoint = "glClearStencil")]
        public static extern void ClearStencil (int s);
        [DllImport (LibGL, EntryPoint = "glClear")]
        public static extern void Clear (int mask);
        [DllImport (LibGL, EntryPoint = "glViewport")]
        public static extern void Viewport (int x, int y, int width, int height);
        [DllImport (LibGL, EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode (int mode);
        [DllImport (LibGL, EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix ();
        [DllImport (LibGL, EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix ();
        [DllImport (LibGL, EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity ();
        [DllImport (LibGL, EntryPoint = "glLoadMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LoadMatrixd ([In] double [] m);
        [DllImport (LibGL, EntryPoint = "glMultMatrixd")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void MultMatrixd ([In] double [] m);
        [DllImport (LibGL, EntryPoint = "glTranslated")]
        public static extern void Translated (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glRotated")]
        public static extern void Rotated (double angle, double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glScaled")]
        public static extern void Scaled (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glOrtho")]
        public static extern void Ortho (double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport (LibGL, EntryPoint = "glFrustum")]
        public static extern void Frustum (double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport (LibGL, EntryPoint = "glBegin")]
        public static extern void Begin (int mode);
        [DllImport (LibGL, EntryPoint = "glEnd")]
        public static extern void End ();
        [DllImport (LibGL, EntryPoint = "glColor4f")]
        public static extern void Color4f (float read, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glColor4b")]
        public static extern void Color4b (byte read, byte green, byte blue, byte alpha);
        [DllImport (LibGL, EntryPoint = "glColor4ub")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Color4ub (byte read, byte green, byte blue, byte alpha);
        [DllImport (LibGL, EntryPoint = "glVertex3d")]
        public static extern void Vertex3d (double x, double y, double z);
        [DllImport (LibGL, EntryPoint = "glNormal3f")]
        public static extern void Normal3f (float nx, float ny, float nz);
        [DllImport (LibGL, EntryPoint = "glNormal3d")]
        public static extern void Normal3d (double nx, double ny, double nz);
        [DllImport (LibGL, EntryPoint = "glEdgeFlag")]
        public static extern void EdgeFlag (int flag);
        [DllImport (LibGL, EntryPoint = "glLineStipple")]
        public static extern void LineStipple (int factor, ushort pattern);
        [DllImport (LibGL, EntryPoint = "glLineWidth")]
        public static extern void LineWidth (float width);
        [DllImport (LibGL, EntryPoint = "glPointSize")]
        public static extern void PointSize (float size);
        [DllImport (LibGL, EntryPoint = "glClipPlane")]
        public static extern void ClipPlane (int plane, [In] double [] equation);
        [DllImport (LibGL, EntryPoint = "glShadeModel")]
        public static extern void ShadeModel (int mode);
        [DllImport (LibGL, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc (int sfactor, int dfactor);
        [DllImport (LibGL, EntryPoint = "glLightModeli")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModeli (int pname, int param);
        [DllImport (LibGL, EntryPoint = "glLightModelfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void LightModelfv (int pname, float [] param);
        [DllImport (LibGL, EntryPoint = "glLightf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightf (int light, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glLightfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Lightfv (int light, int pname, [In] float [] param);
        [DllImport (LibGL, EntryPoint = "glColorMaterial")]
        public static extern void ColorMaterial (int face, int mode);
        [DllImport (LibGL, EntryPoint = "glMaterialf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialf (int face, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glMaterialfv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Materialfv (int face, int pname, [In] float [] param);
        [DllImport (LibGL, EntryPoint = "glPixelStorei")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void PixelStorei (int pname, int param);
        [DllImport (LibGL, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D (int target, int level, int internalformat, int width, int border, int format, int type, [In] float [] pixels);
        [DllImport (LibGL, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D (int target, int level, int internalformat, int width, int height, int border, int format, int type, byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D (int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);
        [DllImport (LibGL, EntryPoint = "glTexCoord1f")]
        public static extern void TexCoord1f (float f);
        [DllImport (LibGL, EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2f (float s, float t);
        [DllImport (LibGL, EntryPoint = "glTexCoord2d")]
        public static extern void TexCoord2d (double s, double t);
        [DllImport (LibGL, EntryPoint = "glGenTextures")]
        public static extern void GenTextures (int n, [Out] uint [] textures);
        [DllImport (LibGL, EntryPoint = "glDeleteTextures")]
        public static extern void DeleteTextures (int n, [Out] uint [] textures);
        [DllImport (LibGL, EntryPoint = "glBindTexture")]
        public static extern void BindTexture (int target, uint texture);
        [DllImport (LibGL, EntryPoint = "glTexParameteri")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexParameteri (int target, int pname, int param);
        [DllImport (LibGL, EntryPoint = "glTexEnvf")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void TexEnvf (int target, int pname, float param);
        [DllImport (LibGL, EntryPoint = "glHint")]
        public static extern void Hint (int target, int mode);
        [DllImport (LibGL, EntryPoint = "glStencilOp")]
        public static extern void StencilOp (int fail, int zfail, int zpass);
        [DllImport (LibGL, EntryPoint = "glStencilFunc")]
        public static extern void StencilFunc (int func, int refer, uint mask);
        [DllImport (LibGL, EntryPoint = "glAccum")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void Accum (int operation, float val);
        [DllImport (LibGL, EntryPoint = "glClearAccum")]
        public static extern void ClearAccum (float red, float green, float blue, float alpha);
        [DllImport (LibGL, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels (int x, int y, int width, int height, int format, int type, [Out] byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels (int x, int y, int width, int height, int format, int type, [Out] IntPtr pixels);
        [DllImport (LibGL, EntryPoint = "glDrawPixels")]
        public static extern void DrawPixels (int width, int height, int format, int type, [In] byte [] pixels);
        [DllImport (LibGL, EntryPoint = "glRasterPos2i")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void RasterPosi (int x, int y);
        [DllImport (LibGL, EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer (int mode);
        [DllImport (LibGL, EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer (int mode);
        [DllImport (LibGL, EntryPoint = "glPolygonOffset")]
        public static extern void PolygonOffset (float factor, float units);
        [DllImport (LibGL, EntryPoint = "glCullFace")]
        public static extern void CullFace (int mode);
        [DllImport (LibGL, EntryPoint = "glColorMask")]
        public static extern void ColorMask (bool red, bool green, bool blue, bool alpha);
        [DllImport (LibGL, EntryPoint = "glDepthMask")]
        public static extern void DepthMask (bool flag);
        [DllImport (LibGL, EntryPoint = "glGetBooleanv")]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif //DEMO_REMOVE
        public static extern void GetBooleanv (int pname, [Out] bool [] pars);
        [DllImport (LibGL, EntryPoint = "glGetError")]
        public static extern int GetError ();
    }

    [CLSCompliant(false)]
    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class GL {
        public enum GLLibrary {
            Win,
            LibGL,
            OSMesa
        }

        public const int BYTE = 0x1400;
        public const int UNSIGNED_BYTE = 0x1401;
        public const int SHORT = 0x1402;
        public const int UNSIGNED_SHORT = 0x1403;
        public const int INT = 0x1404;
        public const int UNSIGNED_INT = 0x1405;
        public const int FLOAT = 0x1406;
        public const int GL_2_BYTES = 0x1407;
        public const int GL_3_BYTES = 0x1408;
        public const int GL_4_BYTES = 0x1409;
        public const int DOUBLE = 0x140A;

        public const int ZERO = 0;
        public const int ONE = 1;

        public const int TRUE = 1;
        public const int FALSE = 0;

        public const int NEVER = 0x0200;
        public const int LESS = 0x0201;
        public const int EQUAL = 0x0202;
        public const int LEQUAL = 0x0203;
        public const int GREATER = 0x0204;
        public const int NOTEQUAL = 0x0205;
        public const int GEQUAL = 0x0206;
        public const int ALWAYS = 0x0207;

        public const int LIGHTING = 0x0B50;
        public const int SHADE_MODEL = 0x0B54;
        public const int COLOR_MATERIAL = 0x0B57;
        public const int DEPTH_TEST = 0x0B71;
        public const int NORMALIZE = 0x0BA1;
        public const int VIEWPORT = 0x0BA2;
        public const int MODELVIEW_MATRIX = 0x0BA6;
        public const int PROJECTION_MATRIX = 0x0BA7;
        public const int BLEND = 0x0BE2;
        public const int STENCIL_TEST = 0x0B90;

        public const int DEPTH_BUFFER_BIT = 0x00000100;
        public const int ACCUM_BUFFER_BIT = 0x00000200;
        public const int STENCIL_BUFFER_BIT = 0x00000400;
        public const int COLOR_BUFFER_BIT = 0x00004000;

        public const int MODELVIEW = 0x1700;
        public const int PROJECTION = 0x1701;
        public const int TEXTURE = 0x1702;

        public const int POINTS = 0x0000;
        public const int LINES = 0x0001;
        public const int LINE_LOOP = 0x0002;
        public const int LINE_STRIP = 0x0003;
        public const int TRIANGLES = 0x0004;
        public const int TRIANGLE_STRIP = 0x0005;
        public const int TRIANGLE_FAN = 0x0006;
        public const int QUADS = 0x0007;
        public const int QUAD_STRIP = 0x0008;
        public const int POLYGON = 0x0009;

        public const int CLIP_PLANE0 = 0x3000;
        public const int CLIP_PLANE1 = 0x3001;
        public const int CLIP_PLANE2 = 0x3002;
        public const int CLIP_PLANE3 = 0x3003;
        public const int CLIP_PLANE4 = 0x3004;
        public const int CLIP_PLANE5 = 0x3005;

        public const int FLAT = 0x1D00;
        public const int SMOOTH = 0x1D01;

        public const int LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const int LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const int LIGHT_MODEL_AMBIENT = 0x0B53;

        public const int LIGHT0 = 0x4000;
        public const int LIGHT1 = 0x4001;
        public const int LIGHT2 = 0x4002;
        public const int LIGHT3 = 0x4003;
        public const int LIGHT4 = 0x4004;
        public const int LIGHT5 = 0x4005;
        public const int LIGHT6 = 0x4006;
        public const int LIGHT7 = 0x4007;

        public const int AMBIENT = 0x1200;
        public const int DIFFUSE = 0x1201;
        public const int SPECULAR = 0x1202;
        public const int POSITION = 0x1203;
        public const int SPOT_DIRECTION = 0x1204;
        public const int SPOT_EXPONENT = 0x1205;
        public const int SPOT_CUTOFF = 0x1206;
        public const int CONSTANT_ATTENUATION = 0x1207;
        public const int LINEAR_ATTENUATION = 0x1208;
        public const int QUADRATIC_ATTENUATION = 0x1209;

        public const int SRC_COLOR = 0x0300;
        public const int ONE_MINUS_SRC_COLOR = 0x0301;
        public const int SRC_ALPHA = 0x0302;
        public const int ONE_MINUS_SRC_ALPHA = 0x0303;
        public const int DST_ALPHA = 0x0304;
        public const int ONE_MINUS_DST_ALPHA = 0x0305;
        public const int DST_COLOR = 0x0306;
        public const int ONE_MINUS_DST_COLOR = 0x0307;
        public const int SRC_ALPHA_SATURATE = 0x0308;

        public const int FRONT = 0x0404;
        public const int BACK = 0x0405;
        public const int FRONT_AND_BACK = 0x0408;

        public const int EMISSION = 0x1600;
        public const int SHININESS = 0x1601;
        public const int AMBIENT_AND_DIFFUSE = 0x1602;
        public const int COLOR_INDEXES = 0x1603;

        public const int TEXTURE_1D = 0x0DE0;
        public const int TEXTURE_2D = 0x0DE1;

        public const int UNPACK_ALIGNMENT = 0x0CF5;
        public const int PACK_ALIGNMENT = 0x0D05;

        public const int TEXTURE_MAG_FILTER = 0x2800;
        public const int TEXTURE_MIN_FILTER = 0x2801;
        public const int TEXTURE_WRAP_S = 0x2802;
        public const int TEXTURE_WRAP_T = 0x2803;

        public const int CLAMP = 0x2900;
        public const int REPEAT = 0x2901;

        public const int NEAREST = 0x2600;
        public const int LINEAR = 0x2601;

        public const int TEXTURE_ENV_MODE = 0x2200;
        public const int TEXTURE_ENV_COLOR = 0x2201;

        public const int TEXTURE_ENV = 0x2300;

        public const int MODULATE = 0x2100;
        public const int DECAL = 0x2101;

        public const int POINT_SMOOTH = 0x0B10;
        public const int LINE_SMOOTH = 0x0B20;
        public const int POLYGON_SMOOTH = 0x0B41;

        public const int PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        public const int POINT_SMOOTH_HINT = 0x0C51;
        public const int LINE_SMOOTH_HINT = 0x0C52;
        public const int POLYGON_SMOOTH_HINT = 0x0C53;
        public const int FOG_HINT = 0x0C54;

        public const int DONT_CARE = 0x1100;
        public const int FASTEST = 0x1101;
        public const int NICEST = 0x1102;

        public const int COLOR_INDEX = 0x1900;
        public const int STENCIL_INDEX = 0x1901;
        public const int DEPTH_COMPONENT = 0x1902;
        public const int RED = 0x1903;
        public const int GREEN = 0x1904;
        public const int BLUE = 0x1905;
        public const int ALPHA = 0x1906;
        public const int RGB = 0x1907;
        public const int RGBA = 0x1908;
        public const int LUMINANCE = 0x1909;
        public const int LUMINANCE_ALPHA = 0x190A;

        public const int BGR_EXT = 0x80E0;
        public const int BGRA_EXT = 0x80E1;

        public const int KEEP = 0x1E00;
        public const int REPLACE = 0x1E01;
        public const int INCR = 0x1E02;
        public const int DECR = 0x1E03;

        public const int ACCUM = 0x0100;
        public const int LOAD = 0x0101;
        public const int RETURN = 0x0102;
        public const int MULT = 0x0103;
        public const int ADD = 0x0104;

        public const int POLYGON_OFFSET_FACTOR = 0x8038;
        public const int POLYGON_OFFSET_UNITS = 0x2A00;
        public const int POLYGON_OFFSET_POINT = 0x2A01;
        public const int POLYGON_OFFSET_LINE = 0x2A02;
        public const int POLYGON_OFFSET_FILL = 0x8037;

        public const int CULL_FACE = 0x0B44;
        public const int LINE_STIPPLE = 0x0B24;

        public const int DEPTH_WRITEMASK = 0x0B72;
        public const int COLOR_WRITEMASK = 0x0C23;
        public const int RGBA_MODE = 0x0C31;

        public const int MAX_TEXTURE_SIZE = 0x0D33;

        public const int STENCIL_BITS = 0x0D57;

        public static GLLibrary Library { get; set; } = GLLibrary.Win;

        [SecuritySafeCritical]
        public static void Finish() {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Finish();
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Finish();
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Finish();
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Enable(int cap) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Enable(cap);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Enable(cap);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Enable(cap);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Disable(int cap) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Disable(cap);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_Linux.Disable(cap);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Disable(cap);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void GetIntegerv(int pname, int[] param) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.GetIntegerv(pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.GetIntegerv(pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.GetIntegerv(pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void GetDoublev(int pname, [Out] double[] param) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.GetDoublev(pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.GetDoublev(pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.GetDoublev(pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ClearColor(float red, float green, float blue, float alpha) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ClearColor(red, green, blue, alpha);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ClearColor(red, green, blue, alpha);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ClearColor(red, green, blue, alpha);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void DepthFunc(int func) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.DepthFunc(func);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.DepthFunc(func);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.DepthFunc(func);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ClearDepth(float depth) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ClearDepth(depth);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ClearDepth(depth);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ClearDepth(depth);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ClearStencil(int s) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ClearStencil(s);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ClearStencil(s);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ClearStencil(s);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Clear(int mask) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Clear(mask);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Clear(mask);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Clear(mask);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Viewport(int x, int y, int width, int height) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Viewport(x, y, width, height);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Viewport(x, y, width, height);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Viewport(x, y, width, height);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void MatrixMode(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.MatrixMode(mode); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.MatrixMode(mode); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.MatrixMode(mode); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void PushMatrix() {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.PushMatrix(); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.PushMatrix(); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.PushMatrix(); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void PopMatrix() {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.PopMatrix(); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.PopMatrix(); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.PopMatrix(); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void LoadIdentity() {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LoadIdentity(); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LoadIdentity(); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LoadIdentity(); 
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void LoadMatrixd([In] double[] m) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LoadMatrixd(m);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LoadMatrixd(m);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LoadMatrixd(m);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void MultMatrixd([In] double[] m) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.MultMatrixd(m); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.MultMatrixd(m); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.MultMatrixd(m); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Translated(double x, double y, double z) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Translated(x, y, z);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Translated(x, y, z);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Translated(x, y, z);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Rotated(double angle, double x, double y, double z) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Rotated(angle, x, y, z);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Rotated(angle, x, y, z);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Rotated(angle, x, y, z);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Scaled(double x, double y, double z) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Scaled(x, y, z);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Scaled(x, y, z);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Scaled(x, y, z);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Ortho(double left, double right, double bottom, double top, double zNear, double zFar) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Ortho(left, right, bottom, top, zNear, zFar); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Ortho(left, right, bottom, top, zNear, zFar); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Ortho(left, right, bottom, top, zNear, zFar); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Frustum(double left, double right, double bottom, double top, double zNear, double zFar) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Frustum(left, right, bottom, top, zNear, zFar); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Frustum(left, right, bottom, top, zNear, zFar); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Frustum(left, right, bottom, top, zNear, zFar); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Begin(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Begin(mode); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Begin(mode); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Begin(mode); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void End() {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.End();
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.End();
                    break;
                case GLLibrary.Win:
                    GLImport_Win.End();
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Color4f(float read, float green, float blue, float alpha) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Color4f(read, green, blue, alpha);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Color4f(read, green, blue, alpha);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Color4f(read, green, blue, alpha);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Color4b(byte read, byte green, byte blue, byte alpha) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Color4b(read, green, blue, alpha);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Color4b(read, green, blue, alpha);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Color4b(read, green, blue, alpha);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Color4ub(byte read, byte green, byte blue, byte alpha) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Color4ub(read, green, blue, alpha); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Color4ub(read, green, blue, alpha); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Color4ub(read, green, blue, alpha); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Vertex3d(double x, double y, double z) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Vertex3d(x, y, z);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Vertex3d(x, y, z);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Vertex3d(x, y, z);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Normal3f(float nx, float ny, float nz) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Normal3f(nx, ny, nz);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Normal3f(nx, ny, nz);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Normal3f(nx, ny, nz);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Normal3d(double nx, double ny, double nz) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Normal3d(nx, ny, nz);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Normal3d(nx, ny, nz);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Normal3d(nx, ny, nz);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void EdgeFlag(int flag) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.EdgeFlag(flag);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.EdgeFlag(flag);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.EdgeFlag(flag);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void LineStipple(int factor, ushort pattern) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LineStipple(factor, pattern);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LineStipple(factor, pattern);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LineStipple(factor, pattern);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void LineWidth(float width) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LineWidth(width);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LineWidth(width);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LineWidth(width);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void PointSize(float size) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.PointSize(size);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.PointSize(size);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.PointSize(size);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ClipPlane(int plane, double[] equation) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ClipPlane(plane, equation);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ClipPlane(plane, equation);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ClipPlane(plane, equation);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ShadeModel(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ShadeModel(mode);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ShadeModel(mode);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ShadeModel(mode);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void BlendFunc(int sfactor, int dfactor) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.BlendFunc(sfactor, dfactor);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.BlendFunc(sfactor, dfactor);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.BlendFunc(sfactor, dfactor);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void LightModeli(int pname, int param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LightModeli(pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LightModeli(pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LightModeli(pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void LightModelfv(int pname, float[] param) {
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.LightModelfv(pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.LightModelfv(pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.LightModelfv(pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Lightf(int light, int pname, float param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Lightf(light, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Lightf(light, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Lightf(light, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Lightfv(int light, int pname, float[] param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Lightfv(light, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Lightfv(light, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Lightfv(light, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ColorMaterial(int face, int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ColorMaterial(face, mode); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ColorMaterial(face, mode); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ColorMaterial(face, mode);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Materialf(int face, int pname, float param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Materialf(face, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Materialf(face, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Materialf(face, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Materialfv(int face, int pname, float[] param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Materialfv(face, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Materialfv(face, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Materialfv(face, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void PixelStorei(int pname, int param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.PixelStorei(pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.PixelStorei(pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.PixelStorei(pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, float[] pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexImage1D(target, level, internalformat, width, border, format, type, pixels);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexImage1D(target, level, internalformat, width, border, format, type, pixels);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexImage1D(target, level, internalformat, width, border, format, type, pixels);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels); 
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexCoord1f(float f) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexCoord1f(f);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexCoord1f(f);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexCoord1f(f);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexCoord2f(float s, float t) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexCoord2f(s, t);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexCoord2f(s, t);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexCoord2f(s, t);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void TexCoord2d(double s, double t) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexCoord2d(s, t);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexCoord2d(s, t);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexCoord2d(s, t);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void GenTextures(int n, uint[] textures) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.GenTextures(n, textures);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.GenTextures(n, textures);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.GenTextures(n, textures);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void DeleteTextures(int n, uint[] textures) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.DeleteTextures(n, textures);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.DeleteTextures(n, textures);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.DeleteTextures(n, textures);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void BindTexture(int target, uint texture) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.BindTexture(target, texture);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.BindTexture(target, texture);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.BindTexture(target, texture);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void TexParameteri(int target, int pname, int param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexParameteri(target, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexParameteri(target, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexParameteri(target, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void TexEnvf(int target, int pname, float param) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.TexEnvf(target, pname, param);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.TexEnvf(target, pname, param);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.TexEnvf(target, pname, param);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void Hint(int target, int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Hint(target, mode); 
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Hint(target, mode); 
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Hint(target, mode); 
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void StencilOp(int fail, int zfail, int zpass) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.StencilOp(fail, zfail, zpass);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.StencilOp(fail, zfail, zpass);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.StencilOp(fail, zfail, zpass);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void StencilFunc(int func, int refer, uint mask) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.StencilFunc(func, refer, mask);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.StencilFunc(func, refer, mask);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.StencilFunc(func, refer, mask);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void Accum(int operation, float val) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.Accum(operation, val);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.Accum(operation, val);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.Accum(operation, val);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void ClearAccum(float red, float green, float blue, float alpha) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ClearAccum(red, green, blue, alpha);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ClearAccum(red, green, blue, alpha);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ClearAccum(red, green, blue, alpha);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ReadPixels(int x, int y, int width, int height, int format, int type, byte[] pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ReadPixels(int x, int y, int width, int height, int format, int type, IntPtr pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ReadPixels(x, y, width, height, format, type, pixels);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void DrawPixels(int width, int height, int format, int type, byte[] pixels) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.DrawPixels(width, height, format, type, pixels);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.DrawPixels(width, height, format, type, pixels);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.DrawPixels(width, height, format, type, pixels);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void RasterPosi(int x, int y) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.RasterPosi(x, y);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.RasterPosi(x, y);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.RasterPosi(x, y);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ReadBuffer(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ReadBuffer(mode);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ReadBuffer(mode);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ReadBuffer(mode);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void DrawBuffer(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.DrawBuffer(mode);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.DrawBuffer(mode);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.DrawBuffer(mode);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void PolygonOffset(float factor, float units) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.PolygonOffset(factor, units);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.PolygonOffset(factor, units);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.PolygonOffset(factor, units);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void CullFace(int mode) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.CullFace(mode);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.CullFace(mode);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.CullFace(mode);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void ColorMask(bool red, bool green, bool blue, bool alpha) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.ColorMask(red, green, blue, alpha);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.ColorMask(red, green, blue, alpha);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.ColorMask(red, green, blue, alpha);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static void DepthMask(bool flag) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.DepthMask(flag);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.DepthMask(flag);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.DepthMask(flag);
                    break;
            }
        }
        [SecuritySafeCritical]
#if DEBUGTEST //DEMO_REMOVE
        [FxCopSpellCheckingIgnore] //DEMO_REMOVE
#endif  //DEMO_REMOVE
        public static void GetBooleanv(int pname, bool[] pars) { 
            switch (Library) {
                case GLLibrary.LibGL:
                    GLImport_Linux.GetBooleanv(pname, pars);
                    break;
                case GLLibrary.OSMesa:
                    GLImport_OSMesa.GetBooleanv(pname, pars);
                    break;
                case GLLibrary.Win:
                    GLImport_Win.GetBooleanv(pname, pars);
                    break;
            }
        }
        [SecuritySafeCritical]
        public static int GetError() {
            switch (Library) {
                case GLLibrary.LibGL:
                    return GLImport_Linux.GetError();
                case GLLibrary.OSMesa:
                    return GLImport_OSMesa.GetError();
                case GLLibrary.Win:
                default:
                    return GLImport_Win.GetError();
            }
        }
    }

    [CLSCompliant(false)]
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("SpellChecker", "CRRSP01")]
#if DEBUGTEST //DEMO_REMOVE
    [FxCopSpellCheckingIgnore]//DEMO_REMOVE
#endif  //DEMO_REMOVE
    public class GLUImport_Win {
        const string Glu32 = "glu32.dll";

        [DllImport(Glu32, EntryPoint = "gluLookAt")]
        public static extern void LookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);
        [DllImport(Glu32, EntryPoint = "gluPerspective")]
        public static extern void Perspective(double fovy, double aspect, double zNear, double zFar);
        [DllImport(Glu32, EntryPoint = "gluNewQuadric")]
        public static extern IntPtr NewQuadric();
        [DllImport(Glu32, EntryPoint = "gluDeleteQuadric")]
        public static extern IntPtr DeleteQuadric(IntPtr state);
        [DllImport(Glu32, EntryPoint = "gluQuadricNormals")]
        public static extern IntPtr QuadricNormals(IntPtr qobj, int normals);
        [DllImport(Glu32, EntryPoint = "gluPartialDisk")]
        public static extern IntPtr PartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle);
        [DllImport(Glu32, EntryPoint = "gluScaleImage")]
        public static extern int ScaleImage(int format, int widthin, int heightin, int typein, byte[] datain, int widthout, int heightout, int typeout, byte[] dataout);
        [DllImport(Glu32, EntryPoint = "gluScaleImage")]
        public static extern int ScaleImage(int format, int widthin, int heightin, int typein, IntPtr datain, int widthout, int heightout, int typeout, byte[] dataout);
        [DllImport(Glu32, EntryPoint = "gluErrorString")]
        public static extern string ErrorString(int errCode);
        [DllImport(Glu32, EntryPoint = "gluProject")]
        public static extern int Project(double objx, double objy, double objz, [In] double[] modelMatrix, [In] double[] projMatrix, [In] int[] viewport,
            out double winx, out double winy, out double winz);
        [DllImport(Glu32, EntryPoint = "gluUnProject")]
        public static extern int UnProject(double winx, double winy, double winz, [In] double[] modelMatrix, [In] double[] projMatrix, [In] int[] viewport,
            out double objx, out double objy, out double objz);
        [DllImport(Glu32, EntryPoint = "gluNewTess")]
        public static extern IntPtr NewTess();
        [DllImport(Glu32, EntryPoint = "gluTessCallback")]
        public static extern void TessCallback(IntPtr tess, int which, IntPtr fn);
        [DllImport(Glu32, EntryPoint = "gluTessProperty")]
        public static extern void TessProperty(IntPtr tess, int which, double value);
        [DllImport(Glu32, EntryPoint = "gluTessNormal")]
        public static extern void TessNormal(IntPtr tess, double x, double y, double z);
        [DllImport(Glu32, EntryPoint = "gluTessBeginPolygon")]
        public static extern void TessBeginPolygon(IntPtr tess, IntPtr polygon_data);
        [DllImport(Glu32, EntryPoint = "gluTessEndPolygon")]
        public static extern void TessEndPolygon(IntPtr tess);
        [DllImport(Glu32, EntryPoint = "gluTessBeginContour")]
        public static extern void TessBeginContour(IntPtr tess);
        [DllImport(Glu32, EntryPoint = "gluTessEndContour")]
        public static extern void TessEndContour(IntPtr tess);
        [DllImport(Glu32, EntryPoint = "gluTessVertex")]
        public static extern void TessVertex(IntPtr tess, [In] double[] coords, IntPtr data);
        [DllImport(Glu32, EntryPoint = "gluDeleteTess")]
        public static extern void DeleteTess(IntPtr tess);
    }

    [CLSCompliant(false)]
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("SpellChecker", "CRRSP01")]
#if DEBUGTEST //DEMO_REMOVE
    [FxCopSpellCheckingIgnore]//DEMO_REMOVE
#endif  //DEMO_REMOVE
    public class GLUImport_Linux {
        const string LibGLU = "libGLU.so.1";

        [DllImport(LibGLU, EntryPoint = "gluLookAt")]
        public static extern void LookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);
        [DllImport(LibGLU, EntryPoint = "gluPerspective")]
        public static extern void Perspective(double fovy, double aspect, double zNear, double zFar);
        [DllImport(LibGLU, EntryPoint = "gluNewQuadric")]
        public static extern IntPtr NewQuadric();
        [DllImport(LibGLU, EntryPoint = "gluDeleteQuadric")]
        public static extern IntPtr DeleteQuadric(IntPtr state);
        [DllImport(LibGLU, EntryPoint = "gluQuadricNormals")]
        public static extern IntPtr QuadricNormals(IntPtr qobj, int normals);
        [DllImport(LibGLU, EntryPoint = "gluPartialDisk")]
        public static extern IntPtr PartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle);
        [DllImport(LibGLU, EntryPoint = "gluScaleImage")]
        public static extern int ScaleImage(int format, int widthin, int heightin, int typein, byte[] datain, int widthout, int heightout, int typeout, byte[] dataout);
        [DllImport(LibGLU, EntryPoint = "gluScaleImage")]
        public static extern int ScaleImage(int format, int widthin, int heightin, int typein, IntPtr datain, int widthout, int heightout, int typeout, byte[] dataout);
        [DllImport(LibGLU, EntryPoint = "gluErrorString")]
        public static extern string ErrorString(int errCode);
        [DllImport(LibGLU, EntryPoint = "gluProject")]
        public static extern int Project(double objx, double objy, double objz, [In] double[] modelMatrix, [In] double[] projMatrix, [In] int[] viewport, out double winx, out double winy, out double winz);
        [DllImport(LibGLU, EntryPoint = "gluUnProject")]
        public static extern int UnProject(double winx, double winy, double winz, [In] double[] modelMatrix, [In] double[] projMatrix, [In] int[] viewport, out double objx, out double objy, out double objz);
        [DllImport(LibGLU, EntryPoint = "gluNewTess")]
        public static extern IntPtr NewTess();
        [DllImport(LibGLU, EntryPoint = "gluTessCallback")]
        public static extern void TessCallback(IntPtr tess, int which, IntPtr fn);
        [DllImport(LibGLU, EntryPoint = "gluTessProperty")]
        public static extern void TessProperty(IntPtr tess, int which, double value);
        [DllImport(LibGLU, EntryPoint = "gluTessNormal")]
        public static extern void TessNormal(IntPtr tess, double x, double y, double z);
        [DllImport(LibGLU, EntryPoint = "gluTessBeginPolygon")]
        public static extern void TessBeginPolygon(IntPtr tess, IntPtr polygon_data);
        [DllImport(LibGLU, EntryPoint = "gluTessEndPolygon")]
        public static extern void TessEndPolygon(IntPtr tess);
        [DllImport(LibGLU, EntryPoint = "gluTessBeginContour")]
        public static extern void TessBeginContour(IntPtr tess);
        [DllImport(LibGLU, EntryPoint = "gluTessEndContour")]
        public static extern void TessEndContour(IntPtr tess);
        [DllImport(LibGLU, EntryPoint = "gluTessVertex")]
        public static extern void TessVertex(IntPtr tess, [In] double[] coords, IntPtr data);
        [DllImport(LibGLU, EntryPoint = "gluDeleteTess")]
        public static extern void DeleteTess(IntPtr tess);
    }

    [SuppressMessage("SpellChecker", "CRRSP01")]
    public static class GLU {
        public const int SMOOTH = 100000;
        public const int FLAT = 100001;
        public const int NONE = 100002;

        public const int TESS_BEGIN = 100100;
        public const int TESS_BEGIN_DATA = 100106;
        public const int TESS_EDGE_FLAG = 100104;
        public const int TESS_EDGE_FLAG_DATA = 100110;
        public const int TESS_VERTEX = 100101;
        public const int TESS_VERTEX_DATA = 100107;
        public const int TESS_END = 100102;
        public const int TESS_END_DATA = 100108;
        public const int TESS_COMBINE = 100105;
        public const int TESS_COMBINE_DATA = 100111;
        public const int TESS_ERROR = 100103;
        public const int TESS_ERROR_DATA = 100109;

        public const int TESS_WINDING_RULE = 100140;
        public const int TESS_BOUNDARY_ONLY = 100141;
        public const int TESS_TOLERANCE = 100142;

        public const int TESS_WINDING_ODD = 100130;
        public const int TESS_WINDING_NONZERO = 100131;
        public const int TESS_WINDING_POSITIVE = 100132;
        public const int TESS_WINDING_NEGATIVE = 100133;
        public const int TESS_WINDING_ABS_GEQ_TWO = 100134;

        [SecuritySafeCritical]
        public static void LookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.LookAt(eyex, eyey, eyez, centerx, centery, centerz, upx, upy, upz);
            else if(PlatformUtils.IsLinux)
                GLUImport_Linux.LookAt(eyex, eyey, eyez, centerx, centery, centerz, upx, upy, upz);
        }
        [SecuritySafeCritical]
        public static void Perspective(double fovy, double aspect, double zNear, double zFar) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.Perspective(fovy, aspect, zNear, zFar);
            else if(PlatformUtils.IsLinux)
                GLUImport_Linux.Perspective(fovy, aspect, zNear, zFar);
        }
        [SecuritySafeCritical]
        public static IntPtr NewQuadric() {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.NewQuadric();
            return GLUImport_Win.NewQuadric();
        }
        [SecuritySafeCritical]
        public static IntPtr DeleteQuadric(IntPtr state) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.DeleteQuadric(state);
            return GLUImport_Win.DeleteQuadric(state);
        }
        [SecuritySafeCritical]
        public static IntPtr QuadricNormals(IntPtr qobj, int normals) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.QuadricNormals(qobj, normals);
            return GLUImport_Win.QuadricNormals(qobj, normals);
        }
        [SecuritySafeCritical]
        public static IntPtr PartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.PartialDisk(qobj, innerRadius, outerRadius, slices, loops, startAngle, sweepAngle);
            return GLUImport_Win.PartialDisk(qobj, innerRadius, outerRadius, slices, loops, startAngle, sweepAngle);
        }
        [SecuritySafeCritical]
        public static int ScaleImage(int format, int widthin, int heightin, int typein, byte[] datain, int widthout, int heightout, int typeout, byte[] dataout) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.ScaleImage(format, widthin, heightin, typein, datain, widthout, heightout, typeout, dataout);
            return GLUImport_Win.ScaleImage(format, widthin, heightin, typein, datain, widthout, heightout, typeout, dataout);
        }
        [SecuritySafeCritical]
        public static int ScaleImage(int format, int widthin, int heightin, int typein, IntPtr datain, int widthout, int heightout, int typeout, byte[] dataout) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.ScaleImage(format, widthin, heightin, typein, datain, widthout, heightout, typeout, dataout);
            return GLUImport_Win.ScaleImage(format, widthin, heightin, typein, datain, widthout, heightout, typeout, dataout);
        }
        [SecuritySafeCritical]
        public static string ErrorString(int errCode) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.ErrorString(errCode);
            return GLUImport_Win.ErrorString(errCode);
        }
        [SecuritySafeCritical]
        public static int Project(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, out double winx, out double winy, out double winz) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.Project(objx, objy, objz, modelMatrix, projMatrix, viewport, out winx, out winy, out winz);
            return GLUImport_Win.Project(objx, objy, objz, modelMatrix, projMatrix, viewport, out winx, out winy, out winz);
        }
        [SecuritySafeCritical]
        public static int UnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, out double objx, out double objy, out double objz) {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.UnProject(winx, winy, winz, modelMatrix, projMatrix, viewport, out objx, out objy, out objz);
            return GLUImport_Win.UnProject(winx, winy, winz, modelMatrix, projMatrix, viewport, out objx, out objy, out objz);
        }
        [SecuritySafeCritical]
        public static IntPtr NewTess() {
            if (PlatformUtils.IsLinux)
                return GLUImport_Linux.NewTess();
            return GLUImport_Win.NewTess();
        }
        [SecuritySafeCritical]
        public static void TessCallback(IntPtr tess, int which, IntPtr fn) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessCallback(tess, which, fn);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessCallback(tess, which, fn);
        }
        [SecuritySafeCritical]
        public static void TessProperty(IntPtr tess, int which, double value) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessProperty(tess, which, value);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessProperty(tess, which, value);
        }
        [SecuritySafeCritical]
        public static void TessNormal(IntPtr tess, double x, double y, double z) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessNormal(tess, x, y, z);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessNormal(tess, x, y, z);
        }
        [SecuritySafeCritical]
        public static void TessBeginPolygon(IntPtr tess, IntPtr polygon_data) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessBeginPolygon(tess, polygon_data);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessBeginPolygon(tess, polygon_data);
        }
        [SecuritySafeCritical]
        public static void TessEndPolygon(IntPtr tess) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessEndPolygon(tess);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessEndPolygon(tess);
        }
        [SecuritySafeCritical]
        public static void TessBeginContour(IntPtr tess) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessBeginContour(tess);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessBeginContour(tess);
        }
        [SecuritySafeCritical]
        public static void TessEndContour(IntPtr tess) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessEndContour(tess);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessEndContour(tess);
        }
        [SecuritySafeCritical]
        public static void TessVertex(IntPtr tess, double[] coords, IntPtr data) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.TessVertex(tess, coords, data);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.TessVertex(tess, coords, data);
        }
        [SecuritySafeCritical]
        public static void DeleteTess(IntPtr tess) {
            if (PlatformUtils.IsWindows)
                GLUImport_Win.DeleteTess(tess);
            else if (PlatformUtils.IsLinux)
                GLUImport_Linux.DeleteTess(tess);
        }
    }
}
