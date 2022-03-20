export const InputComponent = (props: React.InputHTMLAttributes<HTMLInputElement>) => {
    return (
       <div style={{margin:"10px",display:'flex'}}>
          <label style={{marginRight:'5px'}}>{props.title}</label>
          <input
             maxLength={props.maxLength}
             type="number"
             value={props.value}
             onChange={(e) => props.onChange && props.onChange(e)}
          />
       </div>
    );
 };