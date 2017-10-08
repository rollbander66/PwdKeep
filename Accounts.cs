namespace TestForm
{
    public class Accounts
    {
        public int seq_no { get; set; }
        public string acc_desc { get; set; }
        public string acc_name { get; set; }
        public string acc_pass { get; set; }

        public Accounts() {
        }

        public Accounts(int p_seq_no, string p_accd, string p_accn, string p_accp)
        {
            seq_no   = p_seq_no;
            acc_desc = p_accd;
            acc_name = p_accn;
            acc_pass = p_accp;
        }
    }
}
