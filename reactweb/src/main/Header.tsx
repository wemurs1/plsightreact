import logo from './GloboLogo.png';

type Props = {
  subtitle: string;
};

const Header = ({ subtitle }: Props) => {
  return (
    <header className='row mb-4'>
      <div className='col-5'>
        <img src={logo} alt='logo' className='logo' />
      </div>
      <div className='col-7 mt-5 subtitle'>{subtitle}</div>
    </header>
  );
};

export default Header;
