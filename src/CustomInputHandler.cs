using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mogre.Demo.MogreForm
{
    public class CustomInputHandler
    {
        // Fields
        private const int INTERVAL = 0x11;
        private bool mLastFocus;
        private Point mLastLocation;
        protected float mRot = -0.2f;
        private bool mRotating;
        private bool mSliding;
        private bool mOrbiting;
        private System.Windows.Forms.Timer mTimer = new System.Windows.Forms.Timer();
        protected float mTrans = 0.3f;
        protected float mSlide = 0.01f;
        protected float mScroll = 0.2f;
        protected float mOrbit = 0.4f;
        protected Vector3 mTranslate = Vector3.ZERO;
        protected Vector3 mTranslateMouse = Vector3.ZERO;
        protected Control controlForm;
        protected Control parentForm;
        public Camera cameraRef;

        public Vector3 ModelPosition;
        public bool WasCameraChangedByUser { get; set; }
               
        public CustomInputHandler(Control win, Control parent, Camera theCamera)
        {
            controlForm = win;
            parentForm = parent;
            cameraRef = theCamera;
            parent.KeyDown += new KeyEventHandler(this.HandleKeyDown);
            parent.KeyUp += new KeyEventHandler(this.HandleKeyUp);
            parent.MouseWheel += new MouseEventHandler(HandleMouseWheel);
            win.MouseDown += new MouseEventHandler(this.HandleMouseDown);
            win.MouseUp += new MouseEventHandler(this.HandleMouseUp);
            win.Disposed += new EventHandler(this.win_Disposed);
            win.LostFocus += new EventHandler(this.win_LostFocus);
            win.GotFocus += new EventHandler(this.win_GotFocus);
            this.mTimer.Interval = INTERVAL;
            this.mTimer.Enabled = true;
            this.mTimer.Tick += new EventHandler(this.Timer_Tick);

            ModelPosition = new Vector3(0, 0, 0);
            WasCameraChangedByUser = false;
        }

        protected virtual void HandleKeyDown(object sender, KeyEventArgs e)
        {
            float mTrans = this.mTrans;
            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.Prior:
                    this.mTranslate.y = mTrans;
                    WasCameraChangedByUser = true;
                    return;
                                    
                case Keys.R:
                case Keys.End:
                case Keys.Home:
                case Keys.B:
                case Keys.C:
                    break;

                case Keys.S:
                case Keys.Down:
                    this.mTranslate.z = mTrans;
                    WasCameraChangedByUser = true;
                    return;

                case Keys.W:
                case Keys.Up:
                    this.mTranslate.z = -mTrans;
                    WasCameraChangedByUser = true;
                    return;

                case Keys.Next:
                case Keys.E:
                    this.mTranslate.y = -mTrans;
                    WasCameraChangedByUser = true;
                    return;//break;

                case Keys.Left:
                case Keys.A:
                    this.mTranslate.x = -mTrans;
                    WasCameraChangedByUser = true;
                    return;

                case Keys.Right:
                case Keys.D:
                    this.mTranslate.x = mTrans;
                    WasCameraChangedByUser = true;
                    return;

                default:
                    return;
            }
        }

        protected virtual void HandleKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.Prior:
                case Keys.Next:
                case Keys.E:
                    this.mTranslate.y = 0f;
                    return;// break;

                case Keys.R:
                case Keys.End:
                case Keys.Home:
                case Keys.B:
                case Keys.C:
                    break;

                case Keys.S:
                case Keys.W:
                case Keys.Up:
                case Keys.Down:
                    this.mTranslate.z = 0f;
                    return;

                case Keys.Left:
                case Keys.Right:
                case Keys.A:
                case Keys.D:
                    this.mTranslate.x = 0f;
                    return;

                case Keys.T:
                    (parentForm as MogreForm).TakeScreenshot();
                    break;

                default:
                    return;
            }
        }

        protected virtual void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Cursor.Hide();
                this.mRotating = true;
            }
            if (e.Button == MouseButtons.Left)
            {
                this.mSliding = true;
            }
            if (e.Button == MouseButtons.Middle)
            {
                this.mOrbiting = true;               
            }
        }

        void HandleMouseWheel(object sender, MouseEventArgs e)
        {
            var normVec = cameraRef.Direction.NormalisedCopy;
            cameraRef.Position = cameraRef.Position + normVec * e.Delta * mSlide * mScroll;

            WasCameraChangedByUser = true;
        }

        private void HandleMouseMove(Point delta)
        {
            if (this.mRotating)
            {                
                cameraRef.Yaw(new Degree(delta.X * this.mRot));
                cameraRef.Pitch(new Degree(delta.Y * this.mRot));
                WasCameraChangedByUser = true;
            }
            if (this.mSliding)
            {               

                Vector3 v = cameraRef.Orientation * ((Vector3.UNIT_Y * delta.Y) + (Vector3.UNIT_X * -delta.X));
                cameraRef.Move(new Vector3(v.x * mSlide, v.y * mSlide, v.z * mSlide));
                WasCameraChangedByUser = true;
            }
            if (this.mOrbiting)
            {
                               
                Quaternion cameraRotationAboutWorldY = new Quaternion();
                Quaternion cameraRotationAboutWorldX = new Quaternion();

                cameraRotationAboutWorldY.FromAngleAxis(new Degree(delta.X * mOrbit), Vector3.UNIT_Y);
                cameraRotationAboutWorldX.FromAngleAxis(new Degree(delta.Y * mOrbit), cameraRef.Right);

                // Get the result
                Quaternion result = cameraRotationAboutWorldX * cameraRotationAboutWorldY;

                //cameraRef.Position = mm * cameraRef.Position;
                cameraRef.Position *= result.ToRotationMatrix();                

                cameraRef.LookAt(ModelPosition);
                WasCameraChangedByUser = true;
            }            
        }
             
        protected virtual void HandleMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Cursor.Show();
                this.mRotating = false;
            }
            if (e.Button == MouseButtons.Left)
            {
                this.mSliding = false;
                mTranslate.x = 0;
                mTranslate.y = 0;
                mTranslate.z = 0;
            }
            if (e.Button == MouseButtons.Middle)
            {
                this.mOrbiting = false;                
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.mLastFocus)
            {
                Point position = Cursor.Position;
                position.X -= this.mLastLocation.X;
                position.Y -= this.mLastLocation.Y;
                this.HandleMouseMove(position);
            }
            this.mLastLocation = Cursor.Position;
            

            this.mLastFocus = true;

            if (this.mLastFocus)
            {               
                Vector3 deltaMove = cameraRef.Orientation * this.mTranslate;
                deltaMove.y = mTranslate.y;
                cameraRef.Position += deltaMove;
                //cameraRef.Position += cameraRef.Orientation * this.mTranslate;
                //mTranslate.y = 0;
            }
        }

        private void win_Disposed(object sender, EventArgs e)
        {
            this.mTimer.Enabled = false;
        }

        private void win_GotFocus(object sender, EventArgs e)
        {
            this.mTimer.Enabled = true;
        }

        private void win_LostFocus(object sender, EventArgs e)
        {
            this.mTimer.Enabled = false;
            this.mTranslate = Vector3.ZERO;
        }
    }
}
