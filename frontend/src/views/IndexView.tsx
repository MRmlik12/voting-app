import React from "react";
import IndexTitle from "../components/index/IndexTitle";
import IndexContent from "../components/index/IndexContent";
import "../Styles/Index.sass";

const IndexView = () => {
  return (
    <div className="index">
      <IndexTitle />
      <IndexContent />
    </div>
  );
};

export default IndexView;
