import React from "react";
import PropTypes from "prop-types";

const CheckBoxInput = ({
  name,
  label,
  onChange,
  placeholder,
  checked,
  value,
  error
}) => {
  let wrapperClass = "form-group";
  if (error && error.length > 0) {
    wrapperClass += " " + "has-error";
  }

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <input
          type="checkbox"
          name={name}
          className="form-control"
          placeholder={placeholder}
          checked={checked}
          onChange={onChange}
          value={value}
        />
        {error && <div className="alert alert-danger">{error}</div>}
      </div>
    </div>
  );
};

CheckBoxInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  checked: PropTypes.bool,
  value: PropTypes.string,
  error: PropTypes.string
};

export default CheckBoxInput;
