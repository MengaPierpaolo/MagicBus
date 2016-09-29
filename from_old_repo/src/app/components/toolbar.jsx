import React from 'react'

export default class Toolbar extends React.Component {
    render()
    {
        return (
        <nav role= "navigation" className="navbar navbar-default navbar-fixed-top" >
            <div className="navbar-header">
                <button type="button" data-target="#navbarCollapse" data-toggle="collapse" className="navbar-toggle">
                    <span className="sr-only">Toggle navigation</span>
                    <span className="icon-bar"></span>
                    <span className="icon-bar"></span>
                    <span className="icon-bar"></span>
                </button>
                <a className="navbar-brand"
                    title="Magic Bus Home Page" href="/"><i className="fa fa-bus" aria-hidden="true"></i></a>
            </div>
            <div id="navbarCollapse" className="collapse navbar-collapse">
                <ul className="nav navbar-nav">
                    <li><a href="/">Home</a></li>
                    <li><a href="/">Experiences</a></li>
                </ul>
                <ul className="nav navbar-nav navbar-right">
                    <li className="dropdown">
                        <a href="#" className="dropdown-toggle"
                           data-toggle="dropdown"
                           role="button"
                           aria-haspopup="true"
                           aria-expanded="false">Blah<span className="caret"></span></a>
                        <ul className="dropdown-menu">
                            <li><a href="/en-GB/">English (United Kingdom)</a></li>
                            <li><a href="/en-US/">English (United States)</a></li>
                            <li><a href="/zh-CN/">中文(中华人民共和国)</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="/">
                                <p>Login</p>
                        </a>
                    </li>
                </ul>
            </div>
            </nav>
        )
    }
}