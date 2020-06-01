using MagicGradients;
using NControl.Abstractions;
using NGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace INotifySuma.MyControls
{
    public class GradientButton : NControlView
    //La idea es que en esta clase creemos los nuevos controles de tipo GradientButton: para poderlo hacer 
    //tenemos que heredar de la clase NControlView (NControl.Abstraction namespace)
    {

        private Frame _frame;
        //Creamos una variable privada de la clase Frame para poder acceder a las propiedades de la clase Frame desde dentro
        //de otro método.

        private Label _label;

        private GradientView _gradientView;

        public float BorderRadius
            //Creamos una propiedad completa de tipo float que llamamos BorderRadius (luego veremos que podremos
            //borrar la parte private ya que no la necesitaremos
        {
            get => (float)GetValue(BorderRadiusProperty);
            //Y ahora con el método getter vamos a coger el valor de BorderRadiusProperty y hacemos una conversión 
            //explicita al tipo de dato de BorderRadius
            set
            {
                SetValue(BorderRadiusProperty, value);
                //Y en el setter establecemos un valor para BorderRadius pasandole por parametro la BorderRadiusProperty
                //y el valor a establecer
                Invalidate();
                //por último hacenos un Invalidate, que significa que ha habido un cambio y necesitamos redibujar la 
                //Interfaz Gráfica
            }
        }
        static float initialRadius = 15;
        //Creamos una variable estatica que almacena el valor inicial de la BindableProperty BorderRadius

        public static BindableProperty BorderRadiusProperty =
            BindableProperty.Create(nameof(BorderRadius),
                //Declaramos una BindableProperty que llamamos BorderRadiusProperty y luego pasamos a crear lo que es 
                //la BindableProperty, empezando con la definición de su nombre (que es el de la propiedad que 
                //creamos anteriormente)
                typeof(float),
                //El tipo de dato de la BindableProperty (hemod creado una propiedad BorderRadius de tipo float)
                typeof(GradientButton),
                //el tipo de la clase en que definimos la BindableProperty
                initialRadius,
                //el valor inicial de la propiedad
                propertyChanged: (b, o, n) =>
                //el propertyChanged es un delegado (recibe tre parametros y va a ejecutar una expresión lambda.
                //Los tres parametros son el bindebleObject (b), el viejo valor (o = old), y el nuevo valor (n = new)
                 {
                     var control = (GradientButton)b;
                     //creamos una variable control y hacemos una conversión explicita del bindableObject al tipo de nuestra
                     //clase
                     control.BorderRadius = (float)n;
                     //Asignamos a la variable control que ahora es de tipo GradientButton un nuevo valor a la propiedad
                     //BorderRadius (haciendo una conversión explicita al tipo de dato de esta propiedad)
                 });

        public string Text
        {
            get => (string)GetValue(TextProperty);

            set
            {
                SetValue(TextProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(GradientButton),
                "",
                //el valor inicial de la propiedad
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Text = (string)n;
                });

        public string GradientStyle
        {
            get => (string)GetValue(GradientStyleProperty);

            set
            {
                SetValue(GradientStyleProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty GradientStyleProperty =
            BindableProperty.Create(nameof(GradientStyle),
                typeof(string),
                typeof(GradientButton),
                "linear-gradient(44deg, rgba(243, 243, 243, 0.05) 0%, rgba(243, 243, 243, 0.05) 33.333%,rgba(79, 79, 79, 0.05) 33.333%, rgba(79, 79, 79, 0.05) 66.666%,rgba(9, 9, 9, 0.05) 66.666%, rgba(9, 9, 9, 0.05) 99.999%),linear-gradient(97deg, rgba(150, 150, 150, 0.05) 0%, rgba(150, 150, 150, 0.05) 33.333%,rgba(34, 34, 34, 0.05) 33.333%, rgba(34, 34, 34, 0.05) 66.666%,rgba(40, 40, 40, 0.05) 66.666%, rgba(40, 40, 40, 0.05) 99.999%),linear-gradient(29deg, rgba(56, 56, 56, 0.05) 0%, rgba(56, 56, 56, 0.05) 33.333%,rgba(226, 226, 226, 0.05) 33.333%, rgba(226, 226, 226, 0.05) 66.666%,rgba(221, 221, 221, 0.05) 66.666%, rgba(221, 221, 221, 0.05) 99.999%),linear-gradient(90deg, rgb(163, 238, 211),rgb(149, 75, 252))",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.GradientStyle = (string)n;
                });

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);

            set
            {
                SetValue(CommandProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),
                typeof(ICommand),
                typeof(GradientButton),
                defaultBindingMode:BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Command = (ICommand)n;
                });

        public GradientButton()
        {
            _label = new Label
            {
                TextColor = Xamarin.Forms.Color.Black,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                //Definimos unas cuantas propiedades más para el Label
            };

            _gradientView = new GradientView
            {
                GradientSource = new CssGradientSource
                {
                
                }
            };

            _frame = new Frame
            //Asignamos a la variable _frame la instancia de la clase Frame que antes habíamos directamente instanciado
            //como Content del GradientButton
            {
                Content = new Grid

                {
                    Children =
                    {
                        _gradientView,
                        _label
                    }
                },
                Padding = 0,

                //Después de haber definido el contenido del frame (con la propiedad Content) definimos las propiedades
                //Padding (en 0 para que no haya padding) y CornerRadius (para que las esquinas tengan una forma redondeada).
            };

            Content = _frame;
            //Y por último le decimos que esta variable es el nuestro Content. Esto le hemos hecho para poder tener 
            //acceso a nuestro _frame desde el método Draw
        }

            public override void Draw(ICanvas canvas, Rect rect)
            //Como ya vimos, con la clase Draw vamos a hacer modificaciones de diseño (si no había nada hacemos el 
            //diseño desde cero, que llegaría a ser una modificación de la nada).
            {
                //canvas.DrawLine(rect.Left, rect.Top, rect.Width, rect.Height, NGraphics.Colors.Red);
                //canvas.DrawLine(rect.Width, rect.Top, rect.Left, rect.Height, NGraphics.Colors.Green);

                _frame.CornerRadius = BorderRadius;
                //Asignamos a la propiedad CornerRadius (clase Frame) de la variable _frame la BindableProperty
                //BorderRadius. Ahora podemos ya acceder a ella directamente desde nuestro elemento GradientButton y podemos
                //hacer modificaciones de diseño asignando un nuevo valor al BorderRadius y este cambiará lo que es 
                //el CornerRadius del Frame.
                _label.Text = Text;
                _gradientView.GradientSource = new CssGradientSource
                {
                    Stylesheet = this.GradientStyle
                };
            }

        public override bool TouchesBegan(IEnumerable<NGraphics.Point> points)
        //Con este método de NControlView podemos basicamente manipular que es lo que va a pasar cuando interactuamos 
        //con nuestro control. En nuestro caso queremos por ejemplo que se encoja un para que de la apariencia de que
        //estenmos presionando un botón
        {
            this.ScaleTo(0.96, 50, Easing.CubicInOut);
            //Dentro de este método podemos definir unas cuantas acciones a hacer, como por ejemplo Escalar el botón como 
            //en este caso; también podemos definir por ejemplo que el elemento presionado rote, que cambie el ancho, 
            //que "pierda" los bindings que tenía, que sea visible, etc. 
            //En nuestro ejemplo definimos que haga un SacleTo (escalado) definiendo el porcentaje al que queremos escalar
            //(respecto al original), el tiempo que va a tardar y la aceleración
            return true;
            //Es un método que devuelve un valor booleano con el que indicamos si hemos manipulado (true) o no (false) ç
            //este método. Si es true se aplicará la manipulación al elemento que invoque este método.
        }

        public override bool TouchesCancelled(IEnumerable<NGraphics.Point> points)
        //Aquí podemos definir lo que va a pasar cuando se cancele el toque al botón (básicamente cuando quitemos el dedo
        //del botón para NO presionarlo).
        {
            this.ScaleTo(1, 50, Easing.CubicInOut);
            //Que escale de nuevo pero volviendo al 100% del tamaño original, siempre en 200ms con una aceleración 
            //CubicInOut
            return true;
        }

        public override bool TouchesEnded(IEnumerable<NGraphics.Point> points)
        //Con este método definimos que va a pasar después de haber presionado el elemento (es decir, apoyamos el dedo
        //en el elemento presionandolo y levantamos el dedo dejando de presionarlo)
        {
            this.ScaleTo(1, 50, Easing.CubicInOut);
            //Que escale de nuevo pero volviendo al 100% del tamaño original, siempre en 200ms con una aceleración 
            //CubicInOut
            if(Command!=null&&Command.CanExecute(null))
            {
                Command.Execute(null);
            }
            //Cuando acabe la acción de clicar este elemento, además de volver al escalado inicial, lanzamos un control
            //de que no sea nulo el comando y se pueda ejecutar, y si es así entionces ejecutamos el comando.
            //
            return true;
        }
    }
}
