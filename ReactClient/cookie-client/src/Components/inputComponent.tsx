export const inputComponent = (props: React.InputHTMLAttributes<HTMLInputElement>) => {
    return (
       <div style={{marginTop:"10px"}}>
          <input
             maxLength={props.maxLength}
             type="text"
             value={props.value}
             onChange={(e) => props.onChange && props.onChange(e)}
          />
       </div>
    );
 };