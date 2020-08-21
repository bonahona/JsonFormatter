using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonFormatter {
    public partial class JsonFormatter : Form {
        public JsonFormatter() {
            InitializeComponent();
        }

        private void JsonFormatter_Load(object sender, EventArgs e) {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void btnSubmit_Click(object sender, EventArgs e) {

            txtOutput.Clear();

            try {
                var jsonObject = JsonConvert.DeserializeObject(txtInput.Text);
                var outputText = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                txtOutput.Text = outputText;
            } catch (Exception ex) {
                txtOutput.Text = ex.Message;
            }
        }

        private void txtJsonPathExpression_TextChanged(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtOutput.Text)) {
                    return;
                }

                txtJsonPathOutput.Clear();

                var jsonObject = JToken.Parse(txtInput.Text);
                var selectedTokens = jsonObject.SelectTokens(txtJsonPathExpression.Text);

                txtJsonPathOutput.Text = string.Join(Environment.NewLine, selectedTokens.Select(t => t.ToString()));
            } catch (Exception ex) {
                txtJsonPathOutput.Text = ex.Message;
            }
        }
    }
}
