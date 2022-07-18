using projectV2.Camera;
using projectV2.Displays;
using projectV2.Motions;
using projectV2.python;

namespace projectV2.Models
{
    public class Initializations
    {
        public LcdController Lcd { get; set; } = new LcdController();
        public DCMotorController Motor { get; set; } = new DCMotorController();
        public ServoController Servo { get; set; } = new ServoController();
        public CameraController Camera { get; set; } = new CameraController();
        public SensCommands SensCommands { get; set; } = new SensCommands();
        public ServoPositions ServoPositions { get; set; } = new ServoPositions();
        public PythonController PythonController { get; set; } = new PythonController();
    }
}
