import './Nav.css'
import React from 'react'
import { Link } from 'react-router-dom'

export default props =>
    <aside className="menu-area">
        <nav className="menu">
            <Link to="/"><i className="fa fa-home"></i> Início</Link>
            <Link to="/employee"><i class="fa-solid fa-address-card"></i> Funcionário</Link>
            <Link to="/person"><i className="fa fa-user"></i> Cliente</Link>
            <Link to="/proceeding"><i className="fa-solid fa-clipboard-user"></i> Procedimento</Link>
            <Link to="/attendance"><i class="fa-solid fa-clipboard"></i> Atendimento</Link>
            <Link to="/department"><i class="fa-solid fa-sitemap"></i> Departamento</Link>
        </nav>
    </aside>